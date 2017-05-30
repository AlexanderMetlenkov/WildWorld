using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class CarnivoreMind : Mind
    {
        protected override bool findFood(char moveType)
        {
        // method finds nearest food or animal to hunt
            // find out is there dead animals in field
            bool foundFood = false;
            UnmovableEO nearestDeadAnimal = null;
            foreach (UnmovableEO earthObject in animal.earthField.objects)
                if (earthObject.type == "dead animal")
                {
                    if (nearestDeadAnimal == null) nearestDeadAnimal = earthObject;
                    else if (distance(animal, earthObject) < distance(animal, nearestDeadAnimal))
                        nearestDeadAnimal = earthObject;
                }
            if (nearestDeadAnimal != null)
            {
                if (goal.type == "reproduce")
                {
                    Animal reproduceAnimal = ((Animal)goal.target);
                    goal = Goal.makeGoal("eat", moveType, nearestDeadAnimal);
                    reproduceAnimal.mind.findNewGoal();
                }
                else
                    goal = Goal.makeGoal("eat", moveType, nearestDeadAnimal);
                foundFood = true;
            }
            else {
                // find out is there herbivorous animals in field
                Animal nearestPrey = null;
                foreach (Animal potentialPrey in animal.earthField.animals)
                    if (potentialPrey.mind.type == "herbivorous" && potentialPrey.size <= 1.3 * animal.size && potentialPrey.mind.goal.type != "run away")
                    {
                        if (nearestPrey == null) nearestPrey = potentialPrey;
                        else if (distance(animal, potentialPrey) < distance(animal, nearestPrey))
                            nearestPrey = potentialPrey;
                    }
                if (nearestPrey != null)
                {
                    if (goal.type == "reproduce")
                    {
                        Animal reproduceAnimal = ((Animal)goal.target);
                        goal = Goal.makeGoal("hunt", 'r', nearestPrey);
                        reproduceAnimal.mind.findNewGoal();
                    }
                    else
                        goal = Goal.makeGoal("hunt", 'r', nearestPrey);
                    foundFood = true;
                    if (nearestPrey.mind.goal.type != "reproduce")
                        nearestPrey.mind.goal = Goal.makeGoal("run away", 'r', animal);
                    else {
                        ((Animal)(nearestPrey.mind.goal.target)).mind.goal = Goal.makeGoal("walk", 'w', nearestPrey.mind.goal.target);
                        nearestPrey.mind.goal = Goal.makeGoal("run away", 'r', animal);
                    }
                }
            }
            return foundFood;
        }

        override public void findNewGoal()
        {
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
                    foreach(WaterField waterField in animal.earthField.waterFields)
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
            if (animal.hunger >= 10000 || animal.thirst >= 10000)
            {
                Logger.getLogger().write(animal.name + " died of " + (animal.hunger >= 10000 ? "hunger" : "thirst") + ". What a tragedy!");
                animal.earthField.animals.Remove(animal);
                UnmovableEO deadAnimal = new UnmovableEO(Logger.getLogger(), "dead " + animal.name, animal.size, animal.coords, "dead animal");
                animal.earthField.objects.Add(deadAnimal);
                if (goal.type == "hunt" || goal.type == "reproduce")
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
                if (animal.drowsiness >= 10000)
                {
                    if (goal.type == "hunt" || goal.type == "reproduce")
                        ((Animal)(goal.target)).mind.goal = Goal.makeGoal("walk", 'w', goal.target);
                    goal = Goal.makeGoal("sleep", 's', animal);
                }
                else if (((goal.type == "sleep" && animal.drowsiness <= 8000) || (goal.type != "sleep")) && 
                    animal.thirst >= 8000 && !(goal.type == "drink" && goal.speedType == 'r') && findWater('r')) ;
                else if (((goal.type == "sleep" && animal.drowsiness <= 8000) || (goal.type != "sleep")) && 
                    goal.type != "hunt" && !(goal.type == "drink" && goal.speedType == 'r') &&
                    !(goal.type == "eat" && goal.speedType == 'r') &&
                    animal.hunger >= 8000 && findFood('r')) ;
            }
        }

        override public void striveForGoal()
        {
        // method making something that animal has to do now
            checkCriticalSituation();
            if (goal.type == "hunt")
            {
                if (distance(animal, goal.target) <= 0)
                {
                    animal.earthField.animals.Remove((Animal)goal.target);
                    Logger.getLogger().write(goal.target.name + " was slain by " + animal.name + ". Life is not fair..");
                    UnmovableEO deadAnimal = new UnmovableEO(Logger.getLogger(), "dead " + goal.target.name, goal.target.size, goal.target.coords, "dead animal");
                    animal.earthField.objects.Add(deadAnimal);
                    goal = Goal.makeGoal("eat", 'w', deadAnimal);
                }
                else
                    move(animal.runningSpeed);
            }
            else if (goal.type == "drink")
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
                    if (distance(animal, goal.target) <= 0 && animal.hunger > 40)
                    {
                        animal.hunger -= 40;
                        goal.target.size -= 0.3;
                        if (goal.target.size <= 0)
                        {
                            Logger.getLogger().write(goal.target.name + " was eaten by " + animal.name + "!");
                            animal.earthField.objects.Remove((UnmovableEO)goal.target);
                            findNewGoal();
                        }
                    }
                    else if (animal.hunger <= 40)
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
                        Animal child = new Animal(Logger.getLogger(), animal.name, (animal.size + goal.target.size) / 6, (animal.maxSize + ((Animal)goal.target).maxSize) / 2, new PointF((animal.coords.X + goal.target.coords.X) / 2, (animal.coords.Y + goal.target.coords.Y) / 2), 0, 0, 0, 0, animal.hungerInc, animal.thirstInc, animal.libidoInc, (animal.walkingSpeed + ((Animal)(goal.target)).walkingSpeed) / 2, (animal.runningSpeed + ((Animal)(goal.target)).runningSpeed) / 2, random.Next(2) == 1 ? 'm' : 'f', animal.earthField, "carnivore");
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
            else if (goal.type == "walk")
            {
                findNewGoal();
                if(goal.type == "walk")
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

        public CarnivoreMind(Animal animal)
        {
            this.animal = animal;
            type = "carnivore";
            findNewGoal();
        }
    }
}
