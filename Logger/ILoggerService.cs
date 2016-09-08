using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILoggerService
    {
        string Log(string message);
        string Log(string message, string logId);
        string LogWithFileName(string message, string logFileName);
        string LogWithFileName(string message, string logFileName, string logId);
    }
}
