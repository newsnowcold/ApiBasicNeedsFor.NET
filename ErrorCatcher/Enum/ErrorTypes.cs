using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCatcher.Enum
{
    public class ErrorTypes
    {
        public ErrorTypes()
        {

        }

        public readonly string Exception = "Exception error";
        public readonly string IO = "IOError";
        public readonly string Authorization = "Authorization error";
        public readonly string Authentication = "Authentication error";
    }
}
