using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExersice
{
    internal class NodePQ
    {
        public string value;
        public int priority;
        public NodePQ(string value, int priority)
        {
            this.value = value;
            this.priority = priority;
        }
        public override string ToString()
        {
            return "value: " + value + ", priority: " + priority;
        }
    }
}
