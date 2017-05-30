using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class HerbivorousMind : Mind
    {
        protected override bool findFood(char moveType)
        {
        // find nearest food
            // find out is there plants in field
            bool foundFood = false;
            UnmovableEO nearestPlant = null;
            foreach (UnmovableEO earthObject in animal.earthField.objects)
                if (earthObject.type == "plant")
                {
                    if (nearestPlant == null) nearestPlant = earthObject;
                    else if (distance(animal, earthObject) < distance(animal, nearestPlant))
                        nearestPlant = earthObject;
                }
            if (nearestPlant != null)
            {
                if (goal.type == "reproduce")
                {
                    Animal reproduceAnimal = ((Animal)goal.target);
                    goal = Goal.makeGoal("eat", moveType, nearestPlant);
                    reproduceAnimal.mind.findNewGoal();
                }
                else
                    goal = Goal.makeGoal("eat", moveType, nearestPlant);
                foundFood = true;
            }
            return foundFood;
        }

        override public void findNewGoal()
        {
        // method that finds new goal
            if (animal.thirst >= 3000 && findWater('w')) ;
            else if (animal.hunger >= 5000 && findFood('w')) ;
            else if (animal.libido >= 3000 && findMate()) ;
            else if (animal.drowsiness >= 6000)
                goal = Goal.makeGoal("sleep", 's', animal);
            else if (goal == null || goal.type != "walk")
            {
                Point p = new Point();
                bool satisfies = false;
                while (!satisfies)
                {
                    p = new Point(random.Next(animal.earthField.width), random.Next(animal.earthField.height));
                    foreach (WaterField waterField in animal.earthField.waterFields)
                    {
                        if (waterField.isPointIn(p)) satisfies = true;
                    }
                    if (satisfies) satisfies = false;
                    else satisfies = true;
                }
                goal = Goal.makeGoal("walk", 'w', new SizeCoordObject(0, p));
            }
        }

        protected override void checkCriticalSituation()
        {
        // checking different critical situations like big hunger or thirst
            if (animal.hunger >= 10000 || animal.thirst >= 10000)
            {
                Logger.getLogger().write(animal.name + " died of " + (animal.hunger >= 10000 ? "hunger" : "thirst") + ". What a tragedy!");
                animal.earthField.animals.Remove(animal);
                UnmovableEO deadAnimal = new UnmovableEO(Logger.getLogger(), "dead " + animal.name, animal.size, animal.coords, "dead animal");
                animal.earthField.objects.Add(deadAnimal);
                if (goal.type == "run away" || goal.type == "reproduce")
                {
                    ((Animal)goal.target).mind.findNewGoal();
                }
            }
            else
            {
                if (animal.heaviness >= 10000 && goal.type != "sleep" && goal.type != "reproduce")
                {
                    animal.heaviness = 0;
                    animal.earthField.objects.Add(new Feces(animal.size / 4, new PointF(animal.coords.X, animal.coords.Y)));
                }
                if (goal.type != "run away" && animal.drowsiness >= 10000)
                {
                    if (goal.type == "reproduce")
                        ((Animal)(goal.target)).mind.goal = Goal.makeGoal("walk", 'w', goal.target);
                    goal = Goal.makeGoal("sleep", 's', animal);
                }
                else if ( goal.type != "run away" && 
                    ((goal.type == "sleep" && animal.drowsiness <= 8000) || (goal.type != "sleep")) &&
                    animal.thirst >= 8000 && !(goal.type == "drink" && goal.speedType == 'r') && findWater('r')) ;
                else if (((goal.type == "sleep" && animal.drowsiness <= 8000) || (goal.type != "sleep")) &&
                    !(goal.type == "drink" && goal.speedType == 'r') &&
                    !(goal.type == "eat" && goal.speedType == 'r') &&
                    goal.type != "run away" && animal.hunger >= 8000 && findFood('r')) ;
            }
        }

        override public void striveForGoal()
        {
        // method that doing with animal that it has to do
            //log animal's wishes(or critical situations)
            checkCriticalSituation();
            if (goal.type == "drink")
            {
                if (distance(animal, goal.target) <= 0 && animal.thirst > 25)
                    animal.thirst -= 25;
                else if (animal.thirst <= 25)
                    findNewGoal();
                else
                    move(goal.speedType == 'w' ? animal.walkingSpeed : animal.runningSpeed);
            }
            else if (goal.type == "eat")
            {
                if (animal.earthField.objects.Contains((UnmovableEO)goal.target))
                {
                    if (distance(animal, goal.target) <= 0 && animal.hunger > 70)
                    {
                        animal.hunger -= 70;
                        goal.target.size -= 0.3;
                        if (goal.target.size <= 0)
                        {
                            Logger.getLogger().write(goal.target.name + " was eaten by " + animal.name + "!");
                            animal.earthField.objects.Remove((UnmovableEO)goal.target);
                            findNewGoal();
                        }
                    }
                    else if (animal.hunger <= 70)
                        findNewGoal();
                    else
                        move(goal.speedType == 'w' ? animal.walkingSpeed : animal.runningSpeed);
                }
                else
                    findNewGoal();
            }
            else if (goal.type == "sleep")
            {
                if (animal.drowsiness >= 10)
                    animal.drowsiness -= 10;
                else
                    findNewGoal();
            }
            else if (goal.type == "reproduce")
            {
                if (distance(animal, goal.target) <= 0)
                {
                    ((ReproduceGoal)(goal)).turns++;
                    if (((ReproduceGoal)(goal)).turns >= 120)
                    {
                        Animal child = new Animal(Logger.getLogger(), animal.name, (animal.size + goal.target.size) / 6, (animal.maxSize + ((Animal)goal.target).maxSize) / 2, new PointF((animal.coords.X + goal.target.coords.X) / 2, (animal.coords.Y + goal.target.coords.Y) / 2), 0, 0, 0, 0, animal.hungerInc, animal.thirstInc, animal.libidoInc, (animal.walkingSpeed + ((Animal)(goal.target)).walkingSpeed) / 2, (animal.runningSpeed + ((Animal)(goal.target)).runningSpeed) / 2, random.Next(2) == 1 ? 'm' : 'f', animal.earthField, "herbivorous");
                        animal.earthField.animals.Add(child);
                        animal.libido = 0;
                        ((Animal)goal.target).libido = 0;
                        ((Animal)(goal.target)).mind.findNewGoal();
                        findNewGoal();
                    }
                }
                else
                    move(animal.walkingSpeed);
            }
            else if (goal.type == "run away")
            {
                if (((Animal)goal.target).mind.goal.type == "hunt" && distance(animal, goal.target) > 250)
                {
                    int i = random.Next(2);
                    while (!move(animal.runningSpeed))
                    {
                        double x = animal.coords.X;
                        double y = animal.coords.Y;
                        double x0 = ((RunAwayGoal)goal).runAwayPlace.coords.X;
                        double y0 = ((RunAwayGoal)goal).runAwayPlace.coords.Y;
                        double rx = x0 - x;
                        double ry = y0 - y;
                        double c = Math.Cos((i == 0 ? -1 : 1) * Math.PI / 18 * 10);
                        double s = Math.Sin((i == 0 ? -1 : 1) * Math.PI / 18 * 10);
                        double x1 = x + rx * c - ry * s;
                        double y1 = y + rx * s + ry * c;
                        ((RunAwayGoal)goal).runAwayPlace = new SizeCoordObject(0, new PointF((float)x1, (float)y1));
                    }
                }
                else if (((Animal)goal.target).mind.goal.type != "hunt")
                    findNewGoal();
                else
                {
                    ((RunAwayGoal)goal).runAwayPlace = goal.target;
                    move(animal.runningSpeed);
                }
            }
            else if (goal.type == "walk")
            {
                findNewGoal();
                if (goal.type == "walk")
                {
                    if (distance(animal, goal.target) > 0)
                    {
                        if (move(animal.walkingSpeed)) ;
                        else
                        {
                            Point p = new Point();
                            bool satisfies = false;
                            while (!satisfies)
                            {
                                p = new Point(random.Next(animal.earthField.width), random.Next(animal.earthField.height));
                                foreach (WaterField waterField in animal.earthField.waterFields)
                                {
                                    if (waterField.isPointIn(p)) satisfies = true;
                                }
                                if (satisfies) satisfies = false;
                                else satisfies = true;
                            }
                            goal = Goal.makeGoal("walk", 'w', new SizeCoordObject(0, p));
                        }
                    }
                    else
                    {
                        Point p = new Point();
                        bool satisfies = false;
                        while (!satisfies)
                        {
                            p = new Point(random.Next(animal.earthField.width), random.Next(animal.earthField.height));
                            foreach (WaterField waterField in animal.earthField.waterFields)
                            {
                                if (waterField.isPointIn(p)) satisfies = true;
                            }
                            if (satisfies) satisfies = false;
                            else satisfies = true;
                        }
                        goal = Goal.makeGoal("walk", 'w', new SizeCoordObject(0, p));
                    }
                }
            }
            if (goal.speedType == 'r')
            {
                animal.drowsiness += 3;
                animal.hunger += 3 * animal.hungerInc;
                animal.libido += 3 * animal.libidoInc;
                animal.thirst += 3 * animal.thirstInc;
            }
            else if (goal.speedType == 'w')
            {
                animal.drowsiness += 2;
                animal.hunger += 2 * animal.hungerInc;
                animal.libido += 2 * animal.libidoInc;
                animal.thirst += 2 * animal.thirstInc;
            }
            else
            {
                animal.drowsiness += 1;
                animal.hunger += animal.hungerInc;
                animal.libido += animal.libidoInc;
                animal.thirst += animal.thirstInc;
            }
            animal.heaviness += random.Next(7);
        }

        public HerbivorousMind(Animal animal)
        {
            this.animal = animal;
            type = "herbivorous";
            findNewGoal();
        }
    }
}
