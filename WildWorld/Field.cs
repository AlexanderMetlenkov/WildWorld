using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    abstract class Field : AbsObject
    {
        public Point[] border;
        abstract public bool isPointIn(PointF point);
        public Field(Logger log, string name, Point[] points) : base(log, name)
        {
            border = points;
        }
    }
}
