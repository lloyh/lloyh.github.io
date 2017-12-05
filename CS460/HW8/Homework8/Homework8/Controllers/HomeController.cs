using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Homework8.Models;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private ArtContext db = new ArtContext();

        public ActionResult Index()
        {
            return View();
        }

        
        //public JsonResult Genre(int selection)
        //{


        //}
        
    }
}