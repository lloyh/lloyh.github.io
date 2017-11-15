using Homework5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework5.Controllers
{
    public class HomeController : Controller
    {
        private AddressChangeContext myDatabase = new AddressChangeContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}