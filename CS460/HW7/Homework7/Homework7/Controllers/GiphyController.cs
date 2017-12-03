using Homework7.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static Homework7.Models.GiphyJson;

namespace Homework7.Controllers
{
    public class GiphyController : Controller
    {
        // GET: Giphy
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult SearchGiphy()
        {
            string url = "https://api.giphy.com/v1/gifs/search?api_key="
                       + System.Web.Configuration.WebConfigurationManager.AppSettings["APIKey"]
                       + "&q="
                       + Request.QueryString["search"];

            WebRequest webRequest = WebRequest.Create(url);
            Stream theStream = webRequest.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(theStream);

            RootObject jsonResult = new System.Web.Script.Serialization.JavaScriptSerializer()
                                  .Deserialize<RootObject>(reader.ReadToEnd());

            List<SearchResult> searchResult = new List<SearchResult>();

            for (int i = 0; i < 10; i++)
            {
                SearchResult result = new SearchResult();
                result.image = jsonResult.data[i].images.downsized_medium.url;
                searchResult.Add(result);
            }

            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }
    }
}