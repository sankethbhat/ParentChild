using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class SearchCommand : ICommand
    {
        public Node Execute(NodeList nodeList, string parentNodeValue, string childNodeValue)
        {
            Node node = null;

            foreach (var nodeItem in nodeList)
            {
                if (nodeItem.NodeValue == parentNodeValue)
                {
                    node = nodeItem;
                    break;
                }
                else
                {
                    node = Execute(nodeItem.ChildNodes, parentNodeValue, childNodeValue);

                    if (node != null)
                    {
                        break;
                    }
                }
            }

            return node;
        }
    }
}
