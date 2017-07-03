using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class CommandHandler
    {
        public static Node HandleCommand(CommandType commandName, NodeList nodes, string parentNodeValue, string childNodeValue = "")
        {
            ICommand command = CommandFactory.GetCommand(commandName);

            Node node = command.Execute(nodes, parentNodeValue, childNodeValue);

            return node;
        }
    }
}
