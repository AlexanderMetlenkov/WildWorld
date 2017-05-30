using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    abstract class Mind{
        public static Random random = new Random();
        public string type;
        protected Animal animal;
        public Goal goal;
        protected bool move(int speed)
        {
            double x, y;
            if (goal.type != "run away")
            {
                x = goal.target.coords.X;
                y = goal.target.coords.Y;
            }
            else
            {
                x = ((RunAwayGoal)goal).runAwayPlace.coords.X;
                y = ((RunAwayGoal)goal).runAwayPlace.coords.Y;
            }
            double x0 = animal.coords.X, y0 = animal.coords.Y;
            double cosA = (x - x0) / (Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2)));
            double sinA;
            if (y - y0 >= 0)
                sinA = Math.Sqrt(1 - cosA * cosA);
            else
                sinA = -Math.Sqrt(1 - cosA * cosA);
            if (goal.type != "walk" && goal.type != "run away")
            {
                animal.coords.Y += (float)(speed * sinA);
                animal.coords.X += (float)(speed * cosA);
                return true;
            }
            else if (goal.type == "walk")
            {
                foreach (WaterField waterField in animal.earthField.waterFields)
                {
                    if (waterField.isPointIn(new PointF((float)(animal.coords.X + speed * cosA), (float)(animal.coords.Y + speed * sinA))))
                    {
                        return false;
                    }
                }
                animal.coords.Y += (float)(speed * sinA);
                animal.coords.X += (float)(speed * cosA);
                return true;
            }
            else if (goal.type == "run away")
            {
                foreach (WaterField waterField in animal.earthField.waterFields)
                {
                    if (waterField.isPointIn(new PointF((float)(animal.coords.X - speed * cosA), (float)(animal.coords.Y - speed * sinA))))
                        return false;
                }
                if (!animal.earthField.isPointIn(new PointF((float)(animal.coords.X - speed * cosA), (float)(animal.coords.Y - speed * sinA))))
                    return false;
                else {
                    animal.coords.Y -= (float)(speed * sinA);
                    animal.coords.X -= (float)(speed * cosA);
                    return true;
                }
            }
            return true;
        }
        protected bool findWater(char moveType)
        {
            bool foundWater = false;
            PointF nearestWaterPoint = new Point(-100, -100);
            foreach (WaterField waterField in animal.earthField.waterFields)
            {
                double x, y, A = waterField.A, B = waterField.B;
                double An = waterField.An, Bn = waterField.Bn;
                double x0 = animal.coords.X, y0 = animal.coords.Y;
                double x0_ = waterField.border[0].X, y0_ = waterField.border[0].Y;

                y = (A * An * x0_ + An * B * y0_ - A * An * x0 - A * Bn * y0) / (An * B - A * Bn);
                x = (An * x0 + Bn * y0 - Bn * y) / An;

                PointF potentialWaterPoint = new PointF((float)(x), (float)(y));
                if (potentialWaterPoint.X > animal.earthField.width)
                    potentialWaterPoint = waterField.border[0].X == animal.earthField.width ? waterField.border[0] : waterField.border[1];
                else if (potentialWaterPoint.X < 0)
                    potentialWaterPoint = waterField.border[0].X == 0 ? waterField.border[0] : waterField.border[1];
                else if (potentialWaterPoint.Y > animal.earthField.height)
                    potentialWaterPoint = waterField.border[0].Y == animal.earthField.height ? waterField.border[0] : waterField.border[1];
                else if (potentialWaterPoint.Y < 0)
                    potentialWaterPoint = waterField.border[0].Y == 0 ? waterField.border[0] : waterField.border[1];
                if (nearestWaterPoint.X == -100 && nearestWaterPoint.Y == -100)
                    nearestWaterPoint = potentialWaterPoint;
                else if (distance(animal.coords, potentialWaterPoint) < distance(animal.coords, nearestWaterPoint))
                    nearestWaterPoint = potentialWaterPoint;
            }
            if (! (nearestWaterPoint.X == -100 && nearestWaterPoint.Y == -100))
            {
                if (goal != null && (goal.type == "hunt" || goal.type == "reproduce"))
                {
                    Animal reproduceOrHuntAnimal = ((Animal)goal.target);
                    goal = Goal.makeGoal("drink", moveType, new SizeCoordObject(0, new PointF(nearestWaterPoint.X, nearestWaterPoint.Y)));
                    reproduceOrHuntAnimal.mind.findNewGoal();
                }
                goal = Goal.makeGoal("drink", moveType, new SizeCoordObject(0, new PointF(nearestWaterPoint.X, nearestWaterPoint.Y)));
                foundWater = true;
            }
            return foundWater;
        }
        protected bool findMate()
        {
            bool foundMate = false;
            Animal nearestMate = null;
            foreach (Animal potentialMate in animal.earthField.animals)
                if (potentialMate.name == animal.name && potentialMate.mind.goal.type == "walk" && potentialMate.libido >= 300 && potentialMate.sex != animal.sex)
                {
                    if (nearestMate == null) nearestMate = potentialMate;
                    else if (distance(animal, potentialMate) < distance(animal, nearestMate))
                        nearestMate = potentialMate;
                }
            if (nearestMate != null)
            {
                goal = Goal.makeGoal("reproduce", 'w', nearestMate);
                nearestMate.mind.goal = Goal.makeGoal("reproduce", 'w', animal);
                foundMate = true;
            }
            return foundMate;
        }
        abstract protected bool findFood(char moveType);
        abstract protected void checkCriticalSituation();
        abstract public void findNewGoal();
        abstract public void striveForGoal();

        public double distance(SizeCoordObject obj1, SizeCoordObject obj2)
        {
            return Math.Sqrt(Math.Pow(obj2.coords.X - obj1.coords.X, 2) + Math.Pow(obj2.coords.Y - obj1.coords.Y, 2)) - (obj1.size / 2 + obj2.size / 2);
        }

        public double distance(PointF point1, PointF point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }
    }
}
