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
        ArtContext db = new ArtContext();

        public ActionResult Index()
        {
            var genres = db.Genres.ToList();
            return View(genres);
        }

        public JsonResult Genre(int id)
        {            
            List<ArtWorkData> list = new List<ArtWorkData>();            
            var artList = db.Genres.Where(g => g.GenreID == id)
                .Select(s => s.Classifications)
                .FirstOrDefault()
                .Select(x => new { x.ArtWork.Title, x.ArtWork.Artist.ArtistName })
                .OrderBy(o => o.Title)
                .ToList();            
            foreach (var v in artList)
            {                
                ArtWorkData piece = new ArtWorkData();                
                piece.Artist = v.ArtistName;
                piece.Artwork = v.Title;                
                list.Add(piece);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}