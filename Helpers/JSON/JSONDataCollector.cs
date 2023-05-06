using Helpers.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.JSON
{
    public sealed class JSONDataCollector<TDeserialization,TSelect> 
        where TDeserialization : class
        where TSelect : class
    {
        private readonly string _jsonFilePath;
        public string ContentStr {private set; get; }
        private TDeserialization? DeSerializingObj;
        public TSelect Data { private set; get; }
        public JSONDataCollector(string jsonFilePath)=>_jsonFilePath=jsonFilePath;

        public JSONDataCollector<TDeserialization,TSelect> Read()
        {
            this.ContentStr=File.ReadAllText(_jsonFilePath);
            return this;
        }
        public JSONDataCollector<TDeserialization,TSelect> Validate()
        {
            if (!ValidJson(ContentStr))
                throw new InvalidJsonContentException();

            return this;
        }

        public JSONDataCollector<TDeserialization,TSelect> Convert()
        {
            this.DeSerializingObj = JsonConvert.DeserializeObject<TDeserialization>(this.ContentStr);

            return this;
        }

        public JSONDataCollector<TDeserialization, TSelect> Finalize(Func<TDeserialization,TSelect> selector)
        {
            this.Data = selector(this.DeSerializingObj!);
            return this;
        }
        #region Helpers
        private static bool ValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
