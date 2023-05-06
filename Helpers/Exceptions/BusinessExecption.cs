using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Exceptions
{
    public class BusinessExecption:Exception
    {
        protected BusinessExecption(string message) : base(message)
        {

        }

    }
}
