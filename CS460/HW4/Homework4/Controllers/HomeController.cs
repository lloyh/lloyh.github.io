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
             

        [HttpGet]
        public ActionResult Page1()
        {
            string resultString = "";
            string temperatureString = Request.QueryString["temperature"];
            string unit = Request.QueryString["unit"];
            double result = 0;

            //When loading page, both inputs should be empty, do not evaluate, just return empty view
            if (unit == "" || temperatureString == "" || unit == null || temperatureString == null)   
            {
                ViewBag.response = resultString;
                return View();
            }
            //test if temperature value is a double
            if(!double.TryParse(temperatureString, out double temperatureDouble))
            {          
                resultString = "Error: Temperature must be a number";               
                ViewBag.response = resultString;
                return View();
            }                       
            //temperature is valid, proceed to evaluate unit value
            //test for Fahrenheit
            if(unit == "F" || unit == "f" )
            {
                result = (temperatureDouble - 32) / 1.8;
                resultString = result + " Celsius";
            }
            //test for Celsius
            else if (unit == "C" || unit == "c")
            {
                result = (temperatureDouble * 1.8) +32;
                resultString = result + " Fahrenheit";
            }
            //unit input is not valid
            else
            {
                resultString = "Error: for temperature unit, you can only enter F or f for fahrenheit, or C or c for Celsius";
                ViewBag.response = resultString;
                return View();
            }

            ViewBag.response = resultString;            
            return View();
        }

        [HttpGet]
        public ActionResult Page2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            string resultString = "";
            string temperatureString = form["temperature"];
            string unit = form["unit"];
            double result = 0;

            //When loading page, both inputs should be empty, do not evaluate, just return empty view
            if (unit == "" || temperatureString == "" || unit == null || temperatureString == null)
            {
                ViewBag.response = resultString;
                return View();
            }
            //test if temperature value is a double
            if (!double.TryParse(temperatureString, out double temperatureDouble))
            {
                resultString = "Error: Temperature must be a number";
                ViewBag.response = resultString;
                return View();
            }
            //temperature is valid, proceed to evaluate unit value
            //test for Fahrenheit
            if (unit == "F" || unit == "f")
            {
                result = (temperatureDouble - 32) / 1.8;
                resultString = result + " Celsius";
            }
            //test for Celsius
            else if (unit == "C" || unit == "c")
            {
                result = (temperatureDouble * 1.8) + 32;
                resultString = result + " Fahrenheit";
            }
            //unit input is not valid
            else
            {
                resultString = "Error: for temperature unit, you can only enter F or f for fahrenheit, or C or c for Celsius";
                ViewBag.response = resultString;
                return View();
            }

            ViewBag.response = resultString;
            return View();
        }

        [HttpGet]
        public ActionResult Page3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Page3(string loanAmount, string apr, string loanTerm )
        {
            string returnMessage = "";
            //Calculation
            //retrieve variables
            double theLoanAmount = Convert.ToDouble(loanAmount);
            double theApr = Convert.ToDouble(apr);
            double theLoanTerm = Convert.ToDouble(loanTerm);

            theApr /= 1200;         //adjust apr
            theLoanTerm *= 12;      //convert years to months, it also indicates the number of payments
            double payment = 
                theLoanAmount 
                * (theApr * Math.Pow((1 + theApr), theLoanTerm)) 
                / (Math.Pow((1 + theApr), theLoanTerm) -1);

            double numberOfPayments = theLoanTerm;  //number of payments = number of months to pay off the loan
            double totalAmountToPay = numberOfPayments * payment;

            returnMessage = "Monthly Payment: " + Convert.ToDecimal(payment).ToString("C") + " Number of payments: " + numberOfPayments + " Total cost of loan: " + Convert.ToDecimal(totalAmountToPay).ToString("C");
             
            //ViewBag.response = ("Monthly Payment (as decimal): " + Convert.ToDecimal(payment).ToString("C") + " Number of payments: " + numberOfPayments + " Total cost of loan: " + Convert.ToDecimal(totalAmountToPay).ToString("C"));
            ViewBag.response = (returnMessage);
            return View("Page3_Result");
        }

    }
}