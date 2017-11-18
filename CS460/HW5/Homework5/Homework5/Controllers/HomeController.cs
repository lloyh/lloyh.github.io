using Homework5.DAL;
using Homework5.Models;
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
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: requests
        public ActionResult Requests()
        {
            return View(myDatabase.AddressChanges.ToList());
        }
    }
}