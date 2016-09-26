using ErrorCatcher.Interface;
using ErrorCatcher.Methods;
using ErrorCatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace WebApplication3.Controllers
{
    public class BaseApiController: ApiController
    {
        public ISendCustomError customResponseMsgService = new SendCustomResponse();

        public HttpResponseMessage InvalidModelState(ModelStateDictionary modelState)
        {
            List<Error> errors = new List<Error>();

            foreach (var item in modelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    string errorMessage = "The request is invalid";
                    string errorReason = error.Exception?.Message ?? error.ErrorMessage;

                    errors.Add(new Error()
                    {
                        Message = errorMessage,
                        Reason = $"[{item.Key}] - {errorReason}",
                        Domain = Request.RequestUri.AbsoluteUri
                    });
                }               
            }

            return customResponseMsgService
                .ReturnResponse(Request, 
                                HttpStatusCode.BadRequest, 
                                "The request is invalid", 
                                errors);
        }

        public HttpResponseMessage StatusOk<T>(T arg)
        {
            return Request.CreateResponse(HttpStatusCode.OK, arg);
        }

    }
}