using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class InsertCommand : ICommand
    {
        public Node Execute(NodeList nodeList, string parentNodeValue, string childNodeValue)
        {
            ICommand searchCommand = CommandFactory.GetCommand(CommandType.Search);
            Node parentNode = searchCommand.Execute(nodeList, parentNodeValue);
            Node childNode = null;

            if (parentNode != null)
            {
                // Check if Child node already exists
                childNode = searchCommand.Execute(parentNode.ChildNodes, childNodeValue, childNodeValue);

                if (childNode == null)
                {
                    childNode = new Node()
                    {
                        Parent = parentNode,
                        NodeValue = childNodeValue,
                        ChildNodes = new NodeList()
                    };

                    parentNode.ChildNodes.Add(childNode);
                }
            }
            else
            {
                childNode = new Node()
                {
                    Parent = parentNode,
                    NodeValue = childNodeValue,
                    ChildNodes = new NodeList()
                };

                nodeList.Add(childNode);
            }

            return childNode;
        }
    }
}
