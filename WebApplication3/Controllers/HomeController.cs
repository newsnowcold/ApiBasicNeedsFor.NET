using ErrorCatcher.ApiFilters;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    [CustomApiHandler]
    public class HomeController : Controller
    {
        private LoggerService _loggerService;
        public HomeController()
        {
            
            this._loggerService = new LoggerService(@"C:\Users\User\Desktop\Darrel files");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            throw new Exception();
            return View(this._loggerService.Log("Home page"));
        }
    }
}
