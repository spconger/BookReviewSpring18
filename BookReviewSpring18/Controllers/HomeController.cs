using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewSpring18.Models;//reference models

namespace BookReviewSpring18.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //initialize entities classes
            BookReviewDbEntities db = new BookReviewDbEntities();
            //pass the collection categories to the index as a list
            return View(db.Categories.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}