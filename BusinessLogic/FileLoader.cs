using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FileLoader
    {
        public NodeList LoadCSVFile()
        {
            NodeList nodes = new NodeList();
            string path = Constants.AssemblyDirectory + "\\" + Constants.CSV_FILENAME;

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    nodes.Add(values[1], values[0]);
                }
            }

            return nodes;
        }
    }
}
