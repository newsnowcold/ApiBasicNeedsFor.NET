using ErrorCatcher.ApiFilters;
using ErrorCatcher.Interface;
using ErrorCatcher.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [CustomApiHandler]
    public class ValuesController : BaseApiController
    {       
        /// <summary>
        /// A test api controller
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/values/test/{id}")]
        public HttpResponseMessage Test(TestModel model, int id)
        {
            throw new Exception();

            if (!ModelState.IsValid)
            {
                return this.InvalidModelState(ModelState);
            }

            return this.StatusOk(model);
        }
    }
}
