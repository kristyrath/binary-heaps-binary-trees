using System;
using System.Collections.Generic;
using System.Text;

namespace As4
{
    class DemoClass : IComparable
    {
        public string name;
        public int priority;

        public DemoClass()
        {
            name = "";
            priority = 0;
        }

        public int CompareTo(Object obj)
        {  

            DemoClass sample = (DemoClass)obj;

            if (priority < sample.priority) return -1;
            else if (priority > sample.priority) return 1;
            else return 0;  


        }
        public override string ToString()
        {
            return name + " " + priority + " ";
        }

    }
}
