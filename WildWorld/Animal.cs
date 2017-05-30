using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class Animal : SizeCoordObject
    {
        public double hunger;
        public double thirst;
        public double libido;
        public double drowsiness;
        public int heaviness = 0;
        public double hungerInc;
        public double thirstInc;
        public double libidoInc;
        public int walkingSpeed;
        public int runningSpeed;
        public double maxSize;
        public char sex;
        public Mind mind;
        public EarthField earthField;
        public Animal(Logger log, string name, double size, 
            double maxSize, PointF coords, int hunger, 
            int thirst, int libido, int drowsiness, 
            double hungerInc, double thirstInc, double libidoInc,
            int walkingSpeed, int runningSpeed, char sex, 
            EarthField earthField, string mindType) : base(log, name, size, coords)
        {
            this.maxSize = maxSize;
            this.hunger = hunger;
            this.thirst = thirst;
            this.libido = libido;
            this.drowsiness = drowsiness;
            this.hungerInc = hungerInc;
            this.thirstInc = thirstInc;
            this.libidoInc = libidoInc;
            this.walkingSpeed = walkingSpeed;
            this.runningSpeed = runningSpeed;
            this.sex = sex;
            this.earthField = earthField;
            if (mindType == "carnivore") mind = new CarnivoreMind(this);
            else mind = new HerbivorousMind(this);
        }
        public List<SizeCoordObject> sizeCoordObjects;
        public Animal() { }
    }
}
