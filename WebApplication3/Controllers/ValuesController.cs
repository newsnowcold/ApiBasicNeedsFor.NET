using ErrorCatcher.ApiFilters;
using ErrorCatcher.Interface;
using ErrorCatcher.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    [CustomApiHandler]
    public class ValuesController : ApiController
    {
        ISendCustomError customError = new SendCustomError();
        // GET api/values
        public HttpResponseMessage Get()
        {
            throw new Exception();

            return customError.ReturnResponse(Request, HttpStatusCode.ExpectationFailed, "testing test");            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
