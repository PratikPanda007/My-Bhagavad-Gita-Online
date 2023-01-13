using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BhagavadGita.Helpers;
using BhagavadGita.Models;
using Newtonsoft.Json;

namespace BhagavadGita.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DAUtil util = new DAUtil();
            // Get Chapters
            List<SelectListItem> listOfCh = util.DD_Chapters();
            ViewBag.chLists = listOfCh;
            return View();
        }

        public ActionResult Home()
        {
            DAUtil util = new DAUtil();
            // Get Chapters
            List<SelectListItem> listOfCh = util.DD_Chapters();
            ViewBag.chLists = listOfCh;

            ChapInfoDetails cid = util.GetChDetails();
            ViewData["chapters"] = cid.ChapDetails;
            return View(cid.ChapDetails);
        }

        public JsonResult ChapterSelection(FormCollection form)
        {
            int chId = Convert.ToInt32(form["chId"]);
            DAUtil util = new DAUtil();

            ChapInfoDetails cid = util.GetChDetails();
            JsonResult jsonResult = Json(new { data = cid }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult Result(int chId)
        {
            int chapId = chId;
            ViewBag.chId = chId;

            if (chId != 0)
            {
                DAUtil util = new DAUtil();
                ShlokasDetails sd = util.GetShlokasByChapterNum(chapId);
                ViewBag.ChapterName = sd.ChapterName;
                ViewData["shlokas"] = sd.shlokaDetails;
                return View(sd.shlokaDetails);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
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

        public JsonResult ContactUsForm(FormCollection form)
        {
            string fname = Convert.ToString(form["fname"]);
            string lname = Convert.ToString(form["lname"]);
            string job = Convert.ToString(form["job"]);
            string email = Convert.ToString(form["email"]);
            string message = Convert.ToString(form["message"]);

            DAUtil util = new DAUtil();
            util.ContactUsDetails(fname, lname, job, email, message);

            JsonResult jsonResult = Json(new { data = "Details Submitted" }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult Random()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetRandomShloka(FormCollection form)
        {
            DAUtil util = new DAUtil();
            util.GetRandomShloka();

            RandomShlokaRes cid = util.GetRandomShloka();
            JsonResult jsonResult = Json(new { data = cid }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult TestPage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}