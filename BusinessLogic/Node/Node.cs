using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Node
    {
        public string NodeValue { get; set; }
        public NodeList ChildNodes { get; set; }
        public Node Parent { get; set; }
    }
}
