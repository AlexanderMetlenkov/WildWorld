using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class UnmovableEO : SizeCoordObject
    {
        public string type;
        public double maxSize;
        public UnmovableEO(Logger log, string name, double size, PointF coords, string type) : base(log, name, size, coords)
        {
            this.type = type;
            if (type == "feces" || type == "plant")
                this.name = type;
        }
        public UnmovableEO(double size, PointF coords) : base(size, coords)
        {

        }
        public UnmovableEO(Logger log, string name, double size, double maxSize, PointF coords, string type) : base(log, name, size, coords)
        {
            this.maxSize = maxSize;
            this.type = type;
            if (type == "feces" || type == "plant")
                this.name = type;
        }
    }
}
