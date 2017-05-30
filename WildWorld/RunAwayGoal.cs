using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class RunAwayGoal : Goal
    {
        public SizeCoordObject runAwayPlace;
        public RunAwayGoal(SizeCoordObject target) : base('r', target)
        {
            type = "run away";
            runAwayPlace = target;
        }
    }
}
