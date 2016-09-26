using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCatcher.Models
{
    public class ApiErrorViewModel
    {
        private string _defaultMsg = "An unexpected error occures, call the site help desk and sent them the log Id for investigation";

        public ApiErrorViewModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Errors = new List<Error>();
            this.Code = HttpStatusCode.InternalServerError;
            this.Message = ConfigurationManager.AppSettings["GlobalErrorMessage"] ??  _defaultMsg;
        }

        public string Id { get; set; }
        public List<Error> Errors { get; set; }
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }

    public class Error
    {
        public string Domain { get; set; }
        public string Reason { get; set; }
        public string Message { get; set; }
        public string LocationType { get; set; }
        public string Location { get; set; }
    }
}
