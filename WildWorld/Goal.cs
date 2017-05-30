using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    abstract class Goal
    {
        public string type;
        public char speedType;
        public SizeCoordObject target;
        public Goal(char speedType, SizeCoordObject target)
        {
            this.speedType = speedType;
            this.target = target;
        }
        public static Goal makeGoal(string type, char speedType, SizeCoordObject target)
        {
        // method creats goal
            if (type == "hunt" || type == "sleep" || type == "eat" || type == "drink" || type == "walk")
                return new HuntOrRecoveryGoal(type, speedType, target);
            else if (type == "reproduce")
                return new ReproduceGoal(speedType, target);
            else
                return new RunAwayGoal(target);
    
        }
    }
}
