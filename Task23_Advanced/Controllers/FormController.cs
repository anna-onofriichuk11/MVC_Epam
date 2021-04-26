using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Task23_Advanced.Controllers
{
    public class FormController : Controller
    {
        static List<string> validationErrors = new List<string>();
        static List<string> args = new List<string>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Result()
        {
            return View(args);
        }

        [HttpPost]
        public ActionResult SubmitData()
        {
            validationErrors = new List<string>();
            args = new List<string>();

            bool flag = true;
            Regex nameRegex = new Regex("[A-Za-z]+");

            try
            {
                Match match = nameRegex.Match(Request.Form["FirstName"]);
                if (!match.Success)
                {
                    validationErrors.Add("Invalid firstname!");
                    flag = false;
                }

                match = nameRegex.Match(Request.Form["LastName"]);
                if (!match.Success)
                {
                    validationErrors.Add("Invalid lastname!");
                    flag = false;
                }

                Regex emailRegex = new Regex(@"(\w.?)+@[A-Za-z]+.[a-z]+");
                match = emailRegex.Match(Request.Form["Email"]);
                if (!match.Success)
                {
                    validationErrors.Add("Invalid email!");
                    flag = false;
                }

                if (Request.Form["Gender"] == null)
                {
                    validationErrors.Add("Invalid gender!");
                    flag = false;
                }
            }
            catch (Exception e)
            {
                flag = false;
                validationErrors.Add(e.Message);
            }

            if (flag == false) return RedirectToAction("Error");

            args.Add(Request.Form["FirstName"]);
            args.Add(Request.Form["LastName"]);
            args.Add(Request.Form["Email"]);
            args.Add(Request.Form["Gender"]);

            if (Request.Form["Agreement"] != "false") args.Add("Allowed");
            else args.Add("Rejected");

            return RedirectToAction("Result");
        }

        public ActionResult Error()
        {
            return View(validationErrors);
        }
    }
}