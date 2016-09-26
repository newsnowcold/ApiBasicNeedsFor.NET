using ErrorCatcher.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ErrorCatcher.Models;

namespace ErrorCatcher.Methods
{
    public class SendCustomResponse : ISendCustomError
    {
        public HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            var errorResponse = new ApiErrorViewModel();
            errorResponse.Code = statusCode;
            errorResponse.Message = message;

            return request.CreateResponse(statusCode, errorResponse);
        }

        public HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, string logId)
        {
            var errorResponse = new ApiErrorViewModel();
            errorResponse.Code = statusCode;
            errorResponse.Message = message;
            errorResponse.Id = logId;

            return request.CreateResponse(statusCode, errorResponse);
        }

        public HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, List<Error> errors)
        {
            var errorResponse = new ApiErrorViewModel();
            errorResponse.Code = statusCode;
            errorResponse.Message = message;
            errorResponse.Errors = errors;

            return request.CreateResponse(statusCode, errorResponse);
        }
        
        public HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, string logId, List<Error> errors)
        {
            var errorResponse = new ApiErrorViewModel();
            errorResponse.Code = statusCode;
            errorResponse.Message = message;
            errorResponse.Errors = errors;
            errorResponse.Id = logId;

            return request.CreateResponse(statusCode, errorResponse);
        }
    }
}
