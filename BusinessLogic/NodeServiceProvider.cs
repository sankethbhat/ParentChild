using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NodeServiceProvider
    {
        /// <summary>
        /// This method finds the parent name based on the child name.
        /// </summary>
        /// <param name="childName"></param>
        /// <returns></returns>
        public string GetParent(string childName)
        {
            var node = CommandHandler.HandleCommand(CommandType.Search, CacheHandler.Nodes, childName);

            string parentName = node != null && node.Parent != null ? node.Parent.NodeValue : string.Empty;

            return parentName;
        }

        /// <summary>
        /// This method finds the list of children based on the no of children and which page results will be displayed.
        /// API has been designed by handling pagination for the searched results.
        /// </summary>
        /// <param name="parentName">Parent Name</param>
        /// <param name="noOfChildren">No of children list app can handle</param>
        /// <param name="page">Pagination no</param>
        /// <returns></returns>
        public List<string> GetChildren(string parentName, int noOfChildren, int page)
        {
            var node = CommandHandler.HandleCommand(CommandType.Search, CacheHandler.Nodes, parentName);

            var children = node != null ? (node.ChildNodes.Skip((page - 1) * noOfChildren).Take(noOfChildren)) : new NodeList();

            return children.Select(item => item.NodeValue).ToList();
        }

        /// <summary>
        /// This method finds the complete subtree based on the parent name and no of children your app can handle at each parent.
        /// </summary>
        /// <param name="parentName">Parent Name</param>
        /// <param name="childrenDepth">No of Children you app can handle for the complete sub tree</param>
        /// <returns></returns>
        public Node GetParent(string parentName, int childrenDepth)
        {
            var node = CommandHandler.HandleCommand(CommandType.Search, CacheHandler.Nodes, parentName);
            Node filteredNode = null;

            if (node != null)
            {
                filteredNode = new Node() { NodeValue = node.NodeValue, ChildNodes = new NodeList() };
                int depth = Math.Min(node.ChildNodes.Count, childrenDepth);

                for (int i = 0; i < depth; i++)
                {
                    filteredNode.ChildNodes.Add(GetParent(node.ChildNodes[i].NodeValue, childrenDepth));
                }
            }

            return filteredNode;
        }
    }
}
