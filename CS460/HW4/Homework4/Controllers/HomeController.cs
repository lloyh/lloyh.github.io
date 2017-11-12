using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Default action result for home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }        

        /// <summary>
        /// Page 1 temperature convertion page via Get method
        /// </summary>
        /// <returns>viewbag string containing the temperature conversion</returns>
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

        /// <summary>
        /// Default action result page via Get method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Page2()
        {
            return View();
        }

        /// <summary>
        /// Action result page 2 via Post Method
        /// </summary>
        /// <param name="form">form object variables temperature and unit</param>
        /// <returns>viebag string with temperature conversion</returns>
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

        /// <summary>
        /// Returns default view for Page 3
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Page3()
        {
            return View();
        }

        /// <summary>
        /// Calculates a loan monthly payment
        /// </summary>
        /// <param name="loanAmount"> The loan amount to borrow from a lender</param>
        /// <param name="apr"> the interest rate</param>
        /// <param name="loanTerm"> The number of years to repay the loan and interest back</param>
        /// <returns>Returns the monthly payment amount, the number of payments and the total sum of 
        /// payments on a different view called "Page3_Result"</returns>
        [HttpPost]
        public ActionResult Page3(string loanAmount, string apr, string loanTerm )
        {
            //When loading page, both inputs should be empty, do not evaluate, just return empty view
            if (loanAmount == null || apr == null || loanTerm == null || loanAmount == "" || apr == "" || loanTerm == "")
            {                
                return View();
            }

            string returnMessage = "";  //string that holds ViewBag return message

            //Attempt to parse the input into doubles by placing them into double type variables
            if (!double.TryParse(loanAmount, out double theLoanAmount) || !double.TryParse(apr, out double theApr) || 
                !double.TryParse(loanTerm, out double theLoanTerm))
            {
                returnMessage = "Error: Invalid input, please only enter whole umbers or decimals into text boxes";
                ViewBag.response = returnMessage;
                return View("Page3_Result");
            }
            
            //Calculation
            //retrieve variables
            
            theApr /= 1200;         //adjust apr
            theLoanTerm *= 12;      //convert years to months, it also indicates the number of payments
            double payment = 
                theLoanAmount 
                * (theApr * Math.Pow((1 + theApr), theLoanTerm)) 
                / (Math.Pow((1 + theApr), theLoanTerm) -1);

            double numberOfPayments = theLoanTerm;  //number of payments = number of months to pay off the loan
            double totalAmountToPay = numberOfPayments * payment;

            returnMessage = "Monthly Payment: " + Convert.ToDecimal(payment).ToString("C") + ", Number of payments: " + 
                numberOfPayments + ", Total cost of loan: " + Convert.ToDecimal(totalAmountToPay).ToString("C");
            
            ViewBag.response = (returnMessage);
            return View("Page3_Result");
        }

    }
}