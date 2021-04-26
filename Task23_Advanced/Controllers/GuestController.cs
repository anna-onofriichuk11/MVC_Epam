using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Task23_Advanced.Controllers
{
    public class GuestController : Controller
    {
        static List<Review> Reviews = new List<Review>();

        public ActionResult Index()
        {
            ViewBag.Reviews = Reviews;
            return View();
        }

        [HttpPost]
        public ActionResult AddReview()
        {
            bool flag = true;
            Regex textRegex = new Regex("[A-Za-z]+");

            try
            {
                Match match = textRegex.Match(Request.Form["name"]);

                if (!match.Success)
                {
                    flag = false;
                }

                match = textRegex.Match(Request.Form["textReview"]);

                if (!match.Success)
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }

            if (flag == true)
            {
                Reviews.Add(
                    new Review
                    {
                        AuthorName = Request.Form["name"],
                        Date = DateTime.Now,
                        Content = Request.Form["textReview"]
                    });
                Reviews.Reverse();
            }

            return RedirectToAction("Index");

        }
    }

    public class Review
    {
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}