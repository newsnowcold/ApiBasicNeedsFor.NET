﻿using System;
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

        public string Log(string message)
        {
            string fileName = (this._logFileName != "") ?
                this._logFileName : DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");

            string filePath = $"{this._logUrl}{fileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            string logTracker = Guid.NewGuid().ToString();

            File.AppendAllText(filePath, $"[{logTracker}] - {DateTime.UtcNow.TimeOfDay} || {message} {Environment.NewLine}");

            return $"log identifier - {logTracker}";
        }

        public string Log(string message, string logId)
        {
            string fileName = (this._logFileName != "") ?
               this._logFileName : DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");

            string filePath = $"{this._logUrl}{fileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            File.AppendAllText(filePath, $"[{logId}] - {DateTime.UtcNow.TimeOfDay} || {message} {Environment.NewLine}");

            return $"log identifier - {logId}";
        }

        public string LogWithFileName(string message, string logFileName)
        {
            string fileName = (logFileName != "") ?
               logFileName : DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");

            string filePath = $"{this._logUrl}{fileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            string logTracker = Guid.NewGuid().ToString();

            File.AppendAllText(filePath, $"[{logTracker}] - {DateTime.UtcNow.TimeOfDay} || {message} {Environment.NewLine}");

            return $"log identifier - {logTracker}";
        }

        public string LogWithFileName(string message, string logFileName, string logId)
        {
            string fileName = (logFileName != "") ?
                logFileName : DateTime.UtcNow.ToString("dddd, MMMM d, yyyy");

            string filePath = $"{this._logUrl}{fileName}.txt";

            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();

            File.AppendAllText(filePath, $"[{logId}] - {DateTime.UtcNow.TimeOfDay} || {message} {Environment.NewLine}");

            return $"log identifier - {logId}";
        }

       
    }
}
