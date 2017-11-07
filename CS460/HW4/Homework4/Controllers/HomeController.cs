using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is my application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This is my contact page.";

            return View();
        }
        /*
        public ActionResult Page1()
        {
            ViewBag.Message = "Page 1.";

            return View();
        }
        */
        

        [HttpGet]
        public ActionResult Page1()
        {
            string resultString = "";
            string temperatureString = Request.QueryString["temperature"];
            if(!double.TryParse(temperatureString, out double temperatureDouble))
            {
                resultString = "Error: Temperature must be a number";
                ViewBag.response = resultString;
                return View();
            }

            string unit = Request.QueryString["unit"];
            double result = 0;            

            if(unit == "F" || unit == "f" )
            {
                result = (temperatureDouble - 32) / 1.8;
                resultString = result + " Celsius";
            }
            else if (unit == "C" || unit == "c")
            {
                result = (temperatureDouble * 1.8) +32;
                resultString = result + " Fahrenheit";

            }
            else
            {
                resultString = "Error: for temperature unit, you can only enter F or f for fahrenheit, or C or c for Celsius";
                ViewBag.response = resultString;
                return View();
            }

            ViewBag.response = resultString;            
            return View();
        }



    }
}