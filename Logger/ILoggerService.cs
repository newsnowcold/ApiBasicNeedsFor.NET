using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILoggerService
    {
        /// <summary>
        /// If you just wanted to log an event
        /// </summary>
        /// <param name="message">log content</param>
        /// <returns></returns>
        string Log(string message);

        /// <summary>
        /// If you want to log an event with a specific logId
        /// </summary>
        /// <param name="message">log content</param>
        /// <param name="logId">log Id</param>
        /// <returns></returns>
        string Log(string message, string logId);

        /// <summary>
        /// If you want to log an e vent with a specific filename
        /// </summary>
        /// <param name="message">log content</param>
        /// <param name="logFileName">log Id</param>
        /// <returns></returns>
        string LogWithFileName(string message, string logFileName);

        /// <summary>
        /// If you want to log an event with a specific file name and specific log Id
        /// </summary>
        /// <param name="message">log conent</param>
        /// <param name="logFileName">log filename</param>
        /// <param name="logId">log Id</param>
        /// <returns></returns>
        string LogWithFileName(string message, string logFileName, string logId);
    }
}
