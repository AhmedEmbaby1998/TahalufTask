using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Exceptions
{
    public class InvalidJsonContentException : BusinessExecption
    {
        public InvalidJsonContentException() : base("invalid json content")
        {
        }
    }
}
