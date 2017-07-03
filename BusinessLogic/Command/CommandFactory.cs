using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class CommandFactory
    {
        public static ICommand GetCommand(CommandType commandName)
        {
            ICommand command = null;

            switch (commandName)
            {
                case CommandType.Insert:
                    {
                        command = new InsertCommand();
                        break;
                    }
                case CommandType.Delete:
                    {
                        command = new DeleteCommand();
                        break;
                    }
                case CommandType.Search:
                    {
                        command = new SearchCommand();
                        break;
                    }
            }

            return command;
        }
    }
}
