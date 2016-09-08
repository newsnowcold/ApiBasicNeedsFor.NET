using ErrorCatcher.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCatcher.Models
{
    public class ApiErrorModel
    {
        private string _message = "Opps! An error just happend!";
        private string _content = "An unexpected error occures, call the site help desk and sent them the log Id for investigation";

        public ApiErrorModel()
        {
            this.LogId = Guid.NewGuid().ToString();
            this.Message = ConfigurationManager.AppSettings["GlobalErrorMessage"] ?? _message;
            this.Content = ConfigurationManager.AppSettings["GlobalErrorContent"] ?? _content;
            this.ErrorType = new ErrorTypes().Exception;
            this.Status = HttpStatusCode.InternalServerError;
        }

        public HttpStatusCode Status { get; set; }
        public string ErrorType { get; set; }
        public string Content { get; set; }
        public string Message { get; set; }
        public string LogId { get; set; }
    }
}
