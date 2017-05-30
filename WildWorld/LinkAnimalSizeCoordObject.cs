using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class LinkAnimalSizeCoordObject
    {
        public Dictionary<int, Animal> animals = new Dictionary<int, Animal>();
        public Dictionary<int, SizeCoordObject> sizeCoordObjects = new Dictionary<int, SizeCoordObject>();

        public void Add(int animal_id, int sizeCoordObject_id)
        {
            if (animals.ContainsKey(animal_id) && sizeCoordObjects.ContainsKey(sizeCoordObject_id))
            {
                if (!animals[animal_id].sizeCoordObjects.Contains(sizeCoordObjects[sizeCoordObject_id]))
                {
                    animals[animal_id].sizeCoordObjects.Add(sizeCoordObjects[sizeCoordObject_id]);
                    sizeCoordObjects[sizeCoordObject_id].animals.Add(animals[animal_id]);
                }
            }
            else if (!animals.ContainsKey(animal_id))
            {
                if (sizeCoordObjects.ContainsKey(sizeCoordObject_id))
                {
                    animals.Add(animal_id, new Animal());
                    animals[animal_id].sizeCoordObjects.Add(sizeCoordObjects[sizeCoordObject_id]);
                    sizeCoordObjects[sizeCoordObject_id].animals.Add(animals[animal_id]);
                }
                else
                {
                    animals.Add(animal_id, new Animal());
                    sizeCoordObjects.Add(sizeCoordObject_id, new SizeCoordObject());
                    animals[animal_id].sizeCoordObjects.Add(sizeCoordObjects[sizeCoordObject_id]);
                    sizeCoordObjects[sizeCoordObject_id].animals.Add(animals[animal_id]);
                }
            }
            else
            {
                sizeCoordObjects.Add(sizeCoordObject_id, new SizeCoordObject());
                animals[animal_id].sizeCoordObjects.Add(sizeCoordObjects[sizeCoordObject_id]);
                sizeCoordObjects[sizeCoordObject_id].animals.Add(animals[animal_id]);
            }
        }
    }
}
