using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NodeList : List<Node>
    {
        public void Add(string parentNodeValue, string childNodeValue)
        {
            CommandHandler.HandleCommand(CommandType.Insert, this, parentNodeValue, childNodeValue);
        }

        public void Remove(string nodeValue)
        {
            CommandHandler.HandleCommand(CommandType.Delete, this, nodeValue);
        }

        public Node Find(string nodeValue)
        {
            var node = CommandHandler.HandleCommand(CommandType.Search, this, nodeValue);

            return node;
        }
        public static void PrintPretty(Node node, string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(node.NodeValue);

            for (int i = 0; i < node.ChildNodes.Count; i++)
                PrintPretty(node.ChildNodes[i], indent, i == node.ChildNodes.Count - 1);
        }
    }
}
