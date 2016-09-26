using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class LoggerService : ILoggerService
    {

        private string _logUrl;
        private string _logFileName;

        /// <summary>
        /// Put all logs under a single file path
        /// </summary>
        /// <param name="logUrl">folder path</param>
        public LoggerService(string logUrl)
        {
            if (logUrl.EndsWith(@"/"))
            {
                this._logUrl = logUrl;
            }
            else
            {
                this._logUrl = $@"{logUrl}\";
            }

            this._logFileName = "";
        }

        /// <summary>
        /// Use this if you want all your logs will be inserted to a single file
        /// </summary>
        /// <param name="logUrl">file path</param>
        /// <param name="logFileName">file name</param>
        public LoggerService(string logUrl, string logFileName)
        {
            if (logUrl.EndsWith(@"\"))
            {
                this._logUrl = logUrl;
            }
            else
            {
                this._logUrl = $@"{logUrl}\";
            }

            this._logFileName = logFileName;
        }

        /// <summary>
        /// If you just wanted to log an event
        /// </summary>
        /// <param name="message">log content</param>
        /// <returns></returns>
        public string Log(string message)
        {
            string utcDateString = DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");
            string fileName = (this._logFileName != "") ?
                this._logFileName : utcDateString;

            string filePath = $"{this._logUrl}/{utcDateString}/{fileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            string logTracker = Guid.NewGuid().ToString();

            File.AppendAllText(filePath, $" ******** [{logTracker}] - {DateTime.UtcNow.TimeOfDay} ******** {Environment.NewLine} {message} {Environment.NewLine}");

            return $"log identifier - {logTracker}";
        }

        /// <summary>
        /// If you want to log an event with a specific logId
        /// </summary>
        /// <param name="message">log content</param>
        /// <param name="logId">log Id</param>
        /// <returns></returns>
        public string Log(string message, string logId)
        {
            string utcDateString = DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");
            string fileName = (this._logFileName != "") ?
               this._logFileName : utcDateString;

            string filePath = $"{this._logUrl}/{utcDateString}/{fileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            File.AppendAllText(filePath, $" ******** [{logId}] - {DateTime.UtcNow.TimeOfDay} ******** {Environment.NewLine} {message} {Environment.NewLine}");

            return $"log identifier - {logId}";
        }

        /// <summary>
        /// If you want to log an e vent with a specific filename
        /// </summary>
        /// <param name="message">log content</param>
        /// <param name="logFileName">log Id</param>
        /// <returns></returns>
        public string LogWithFileName(string message, string logFileName)
        {
            string utcDateString = DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");
            string fileName = (this._logFileName != "") ?
               this._logFileName : utcDateString;

            string filePath = $"{this._logUrl}/{utcDateString}/{logFileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            string logTracker = Guid.NewGuid().ToString();

            File.AppendAllText(filePath, $" ******** [{logTracker}] - {DateTime.UtcNow.TimeOfDay} ******** {Environment.NewLine} {message} {Environment.NewLine}");

            return $"log identifier - {logTracker}";
        }

        /// <summary>
        /// If you want to log an event with a specific file name and specific log Id
        /// </summary>
        /// <param name="message">log conent</param>
        /// <param name="logFileName">log filename</param>
        /// <param name="logId">log Id</param>
        /// <returns></returns>
        public string LogWithFileName(string message, string logFileName, string logId)
        {
            string utcDateString = DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");
            string fileName = (this._logFileName != "") ?
               this._logFileName : utcDateString;

            string filePath = $"{this._logUrl}/{utcDateString}/{logFileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            File.AppendAllText(filePath, $" ******** [{logId}] - {DateTime.UtcNow.TimeOfDay} ******** {Environment.NewLine} {message} {Environment.NewLine}");

            return $"log identifier - {logId}";
        }
       
    }
}
