﻿using System;
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

        public JsonResult GetAllShlokasByChapterNumber()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            //Convert json object to model
            ShlokaReq reqDetails = JsonConvert.DeserializeObject<ShlokaReq>(json);
            try
            {
                DAUtil util = new DAUtil();
                ShlokaRes res = util.GetShlokasByChapterNum_JSON(reqDetails.ChapterNum);

                return Json(res);
            }
            catch
            {
                return Json("'Status' : 'Unable to get you the requested data. Please try later', 'StatusCode' : '500''");
            }
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

            if(chId != 0)
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

        public ActionResult API()
        {
            return View();
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