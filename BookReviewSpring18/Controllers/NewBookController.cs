using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewSpring18.Models;

namespace BookReviewSpring18.Controllers
{
    public class NewBookController : Controller
    {
        // GET: NewBook
        public ActionResult Index()
        {
            
            if(Session["ReviewerKey"]==null)
            {
                //Message m = new Message("You must be logged in to add a book");
                return RedirectToAction("Index","Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="BookTitle, BookEntryDate,BookISBN")]Book b)
        {
            b.BookEntryDate = DateTime.Now;
            //Donation.PersonKey=(int)Session["PersonKey"]
            BookReviewDbEntities db = new BookReviewDbEntities();
            db.Books.Add(b);
            db.SaveChanges();
            Message m = new Message("Book has been entered");
            return View("Result", m);
        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}