using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class ReproduceGoal : Goal
    {
        public byte turns = 0;
        public ReproduceGoal(char speedType, SizeCoordObject target) : base(speedType, target)
        {
            this.type = "reproduce";
        }
    }
}
