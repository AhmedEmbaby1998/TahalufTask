using Helpers.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.JSON
{
    public static class JSONHelpers
    {
        /// <summary>
        /// returns the full path of all JSOn files existed in the folder have the <para>baseURI</para>
        /// </summary>
        /// <param name="baseURI">the full path of the folder</param>
        /// <returns>IEnumerable of the full path of all JSOn Files</returns>
        public static IEnumerable<string> GetAllJSONFiles(this string baseURI) =>
            FilesExtraction.GetFiles(baseURI: baseURI, extensions: new string[] { ".json", ".JSON" });


    }
}
