using ErrorCatcher.Enum;
using ErrorCatcher.Models;
using Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Configuration;

namespace ErrorCatcher.ApiFilters
{
    public class CustomApiHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ILoggerService logger = new LoggerService(this.logUrl);

            var errorResponse = new ApiErrorViewModel();

            Error error = new Error()
            {
                Domain = this.GetDomain(actionExecutedContext.Request),
                Reason = "Unexpected error",
                Message = ""
            };

            var innerException = this.InnerExceptionExtractor(actionExecutedContext.Exception);

            Task.Run(() => logger
                            .LogWithFileName(innerException, 
                                             errorResponse.Id,
                                             errorResponse.Id));

            errorResponse.Errors.Add(error);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(errorResponse))
            });
        }

        #region helper methods
        private string GetDomain(HttpRequestMessage request)
        {
            string scheme = request.RequestUri.Scheme;
            string port = (request.RequestUri.Port == 80 || request.RequestUri.Port == 0 || request.RequestUri.Port == 443) ?
                    "" : $":{request.RequestUri.Port}";

            string host = request.RequestUri.Host;

            var baseUrl = $"{scheme}://{host}{port}";

            return baseUrl;
        }

        private string logUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["LogsUrl"] ?? @"C:\";
            }
        }

        private string InnerExceptionExtractor(Exception e)
        {
            Exception realerror = e;
            while (realerror.InnerException != null)
                realerror = realerror.InnerException;

            return realerror.ToString();
        }
        #endregion
    }
}
