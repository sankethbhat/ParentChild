using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface ICommand
    {
        Node Execute(NodeList nodeList, string value, string childNodeValue = "");
    }
}
