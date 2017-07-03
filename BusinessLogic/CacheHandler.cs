using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CacheHandler
    {
        public static NodeList Nodes
        {
            get
            {
                return GetNodes();
            }
        }
        private static NodeList GetNodes()
        {
            ObjectCache cache = MemoryCache.Default;
            NodeList nodes = cache[Constants.CACHE_KEY] as NodeList;

            if (nodes == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();

                List<string> filePaths = new List<string>();
                filePaths.Add(Constants.AssemblyDirectory + "\\" + Constants.CSV_FILENAME);

                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                // Fetch the file contents.
                nodes = new FileLoader().LoadCSVFile();

                cache.Set("filecontents", nodes, policy);
            }

            return nodes;
        }
    }
}
