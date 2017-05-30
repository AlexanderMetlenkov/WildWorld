using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class AbsObject
    {
        public string name;
        public AbsObject(Logger log, string name)
        {
            this.name = name;
            log.write(name + " was created");
        }
        public AbsObject() { }
    }
}
