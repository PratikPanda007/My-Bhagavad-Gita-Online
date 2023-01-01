using BhagavadGita.Helpers;
using BhagavadGita.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BhagavadGita.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult API()
        {
            return View();
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

        public JsonResult GetShlokaByChapterAndVerseNumber()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            //Convert json object to model
            OneShlokaReq reqDetails = JsonConvert.DeserializeObject<OneShlokaReq>(json);
            try
            {
                DAUtil util = new DAUtil();
                OneShlokaRes res = util.GetShlokaByChapterAndVerseNumber_JSON(reqDetails.ChapterNum, reqDetails.VerseNum);

                return Json(res);
            }
            catch
            {
                return Json("'Status' : 'Unable to get you the requested data. Please try later', 'StatusCode' : '500''");
            }
        }

    }
}