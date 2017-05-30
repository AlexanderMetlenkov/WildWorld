using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class HuntOrRecoveryGoal : Goal
    {
        public HuntOrRecoveryGoal(string type, char speedType, SizeCoordObject target) : base(speedType, target)
        {
            this.type = type;
        }
    }
}
