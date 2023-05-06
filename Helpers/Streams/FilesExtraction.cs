using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Streams
{
    public static class FilesExtraction
    {
        public static IEnumerable<string> GetFiles(string baseURI,string[] extensions)
        {
            string[] folders =
                Directory.GetDirectories(baseURI, "*",SearchOption.AllDirectories);

            foreach(var p in folders)
            {
                if (File.Exists(p))
                {
                    if(extensions.Contains(Path.GetExtension(p)))
                        yield return p;
                }

                GetFiles(baseURI,extensions);
            }

        }
    }
}
