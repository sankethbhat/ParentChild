using BusinessLogic;
using System;

namespace ParentChildAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeServiceProvider nodeManager = new NodeServiceProvider();

            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("Please enter an option");
                Console.WriteLine("1: Getting name of parent from child name");
                Console.WriteLine("2: Getting names of children from parent name");
                Console.WriteLine("3: Getting names of children, grand-children, (the entire subtree) from the parent name.");
                Console.WriteLine("4: Exit");
                Console.WriteLine("-----------------------------------------------------------------------------");

                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        {
                            Console.WriteLine("\n\nPlease enter child name");
                            string childName = Console.ReadLine();
                            string parentName = nodeManager.GetParent(childName);
                            Console.WriteLine("\n\nParent Name: " + (string.IsNullOrEmpty(parentName) ? "Not Found" : parentName));
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("\n\nPlease enter parent name");
                            string childName = Console.ReadLine();
                            Console.WriteLine("\n\nPlease enter no of children your app can handle");
                            int noOfChildren = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n\nPlease enter the page");
                            int page = Convert.ToInt32(Console.ReadLine());

                            var children = nodeManager.GetChildren(childName, noOfChildren, page);
                            children.ForEach(child => { Console.WriteLine("\n\nChild Name: " + child); });

                            if (children.Count == 0)
                                Console.WriteLine("\n\nNo children found");

                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("\n\nPlease enter parent name");
                            string parentName = Console.ReadLine();
                            Console.WriteLine("\n\nPlease enter no of children your app can handle");
                            int noOfChildren = Convert.ToInt32(Console.ReadLine());

                            var parent = nodeManager.GetParent(parentName, noOfChildren);
                            PrintNode(parent, string.Empty, true);

                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case '4':
                        {
                            return;
                        }
                }

                continue;
            }
        }

        public static void PrintNode(Node node, string spacer, bool isLastNode)
        {
            Console.Write(spacer);

            if (isLastNode)
            {
                Console.Write("-");
                spacer += "  ";
            }
            else
            {
                Console.Write("-");
                spacer += " ";
            }

            Console.WriteLine(node.NodeValue);

            for (int i = 0; i < node.ChildNodes.Count; i++)
                PrintNode(node.ChildNodes[i], spacer, i == node.ChildNodes.Count - 1);
        }
    }
}
