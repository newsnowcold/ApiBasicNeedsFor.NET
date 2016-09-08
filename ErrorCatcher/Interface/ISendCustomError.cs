using ErrorCatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ErrorCatcher.Interface
{
    public interface ISendCustomError
    {
        HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message);
        HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, string logId);
        HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, List<Error> errors);
        HttpResponseMessage ReturnResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, string logId, List<Error> errors);

    }
}
