using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class SizeCoordObject : AbsObject
    {
        public PointF coords;
        public double size;
        public SizeCoordObject(Logger log, string name, double size, PointF coords) : base(log, name)
        {
            this.size = size;
            this.coords = coords;
        }
        public SizeCoordObject(double size, PointF coords) : base()
        {
            this.size = size;
            this.coords = coords;
        }
        public List<Animal> animals;
        public SizeCoordObject() { }
    }
}
