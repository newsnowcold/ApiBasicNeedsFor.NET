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
using Newtonsoft.Json.Linq;
using ErrorCatcher.Helper;
using System.Web.Script.Serialization;

namespace ErrorCatcher.ApiFilters
{
    public class CustomApiHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ILoggerService logger = new LoggerService(this.logUrl);

            var errorResponse = new ApiErrorViewModel();

            var arguments = actionExecutedContext.ActionContext.ActionArguments;

            Error error = new Error()
            {
                Domain = this.GetDomain(actionExecutedContext.Request),
                Reason = "Unexpected error",
                Message = ""
            };

            var logString = GetStringToLog(actionExecutedContext);

            Task.Run(() => logger
                            .LogWithFileName(logString,
                                             errorResponse.Id,
                                             errorResponse.Id));

            errorResponse.Errors.Add(error);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(errorResponse))
            });
        }

        #region helper methods

        private string GetStringToLog(HttpActionExecutedContext request)
        {
            StringBuilder logString = new StringBuilder();
            WebApiRequestHelper webApiRequestHelper = new WebApiRequestHelper();
            JavaScriptSerializer js = new JavaScriptSerializer();


            string body = webApiRequestHelper.GetBodyFromRequest(request);

            List<KeyValuePair<string, string>> headers = webApiRequestHelper.GetHeadersFromRequest(request);            
            string stringHeader = js.Serialize(headers);

            var queryStrings = webApiRequestHelper.GetQueryStringFromRequest(request);
            string stringQryStrings = js.Serialize(queryStrings);

            string user = request.ActionContext.RequestContext.Principal.Identity.Name;
            var ctrl = request.ActionContext.ControllerContext.ControllerDescriptor;


            logString.Append(System.Environment.NewLine);
            logString.Append(System.Environment.NewLine);
            logString.Append($"********************{System.Environment.NewLine}");
            logString.Append($"Request details{System.Environment.NewLine}");
            logString.Append($"********************{System.Environment.NewLine}");
            logString.Append($"User: {user}{System.Environment.NewLine}");
            logString.Append($"Url: {request.Request.RequestUri.AbsoluteUri}{System.Environment.NewLine}");
            logString.Append($"Method: {request.Request.Method}{System.Environment.NewLine}{System.Environment.NewLine}");
            logString.Append($"Body content: {System.Environment.NewLine} {body}{System.Environment.NewLine}{System.Environment.NewLine}");
            logString.Append($"Headers: {System.Environment.NewLine}{stringHeader}{System.Environment.NewLine}{System.Environment.NewLine}");
            logString.Append($"Query strings: {System.Environment.NewLine}{stringQryStrings}{System.Environment.NewLine}{System.Environment.NewLine}");

            logString.Append(System.Environment.NewLine);
            logString.Append(System.Environment.NewLine);
            logString.Append($"********************{System.Environment.NewLine}");
            logString.Append($"Controller details{System.Environment.NewLine}");
            logString.Append($"********************{System.Environment.NewLine}");
            logString.Append($"Controller name:{ctrl.ControllerName}{System.Environment.NewLine}");
            logString.Append($"Properties :{PropertiesExtractor(ctrl.Properties)}{System.Environment.NewLine}");

            logString.Append(System.Environment.NewLine);
            logString.Append(System.Environment.NewLine);
            logString.Append($"********************{System.Environment.NewLine}");
            logString.Append($"Stack Trace:{System.Environment.NewLine}");
            logString.Append($"********************{System.Environment.NewLine}");
            logString.Append(this.InnerExceptionExtractor(request.Exception));

            return logString.ToString();
        }      

        private string PropertiesExtractor(IDictionary<object, object> properties)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in properties)
            {
                sb.Append(System.Environment.NewLine);
                sb.Append($"key: {item.Key}");
                sb.Append($"value: {item.Value}");
                sb.Append(System.Environment.NewLine);
            }

            return sb.ToString();
        }

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
                return ConfigurationManager.AppSettings["LogsUrl"] ?? @"C:\ApiLogs";
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
