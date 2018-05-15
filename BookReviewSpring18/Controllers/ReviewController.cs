using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewSpring18.Models;

namespace BookReviewSpring18.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        BookReviewDbEntities db = new BookReviewDbEntities();
        public ActionResult Index()
        {
            if (Session["ReviewerKey"]==null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be logged in to create a review";
                return RedirectToAction("Result", msg);
            }
            ViewBag.BookKey = new SelectList(db.Books, "BookKey", "BookTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="BookKey, ReviewerKey,ReviewDate, ReviewTitle, ReviewText," +
            "ReviewRating")]Review r)
        {
            try
            {
                r.ReviewerKey = (int)Session["ReviewerKey"];
                r.ReviewDate = DateTime.Now;
                db.Reviews.Add(r);
                db.SaveChanges();
                Message m = new Message();
                m.MessageText = "Thank you for your review";
                return RedirectToAction("Result", m);
            }
            catch (Exception e)
            {
                Message m = new Message();
                m.MessageText = e.Message;
                return RedirectToAction("Result", m);
            }
        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }

    }
}