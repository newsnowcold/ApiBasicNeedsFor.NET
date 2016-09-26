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
    public class SendCustomError : ISendCustomError
    {
        /// <summary>
        /// Send a custom response message
        /// </summary>
        /// <param name="request">current request context</param>
        /// <param name="statusCode">the status code of the response message</param>
        /// <param name="message">content of the response</param>
        /// <returns></returns>
        public HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            var errorResponse = new ApiErrorViewModel();
            errorResponse.Code = statusCode;
            errorResponse.Message = message;

            return request.CreateResponse(statusCode, errorResponse);
        }

        /// <summary>
        /// Send a custom response message with a specific LogId
        /// </summary>
        /// <param name="request">current request context</param>
        /// <param name="statusCode">the status code of the response message</param>
        /// <param name="message">content of the response</param>
        /// <param name="logId">custom log id</param>
        /// <returns></returns>
        public HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, string logId)
        {
            var errorResponse = new ApiErrorViewModel();
            errorResponse.Code = statusCode;
            errorResponse.Message = message;
            errorResponse.Id = logId;

            return request.CreateResponse(statusCode, errorResponse);
        }

        /// <summary>
        /// Send a custom response message with a list of errors
        /// </summary>
        /// <param name="request">current request context</param>
        /// <param name="statusCode">response status code</param>
        /// <param name="message">response content</param>
        /// <param name="errors">list of errors</param>
        /// <returns></returns>
        public HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, List<Error> errors)
        {
            var errorResponse = new ApiErrorViewModel();
            errorResponse.Code = statusCode;
            errorResponse.Message = message;
            errorResponse.Errors = errors;

            return request.CreateResponse(statusCode, errorResponse);
        }

        /// <summary>
        /// Send a custom response message with a list of errors together with a specific log Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="logId"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
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
