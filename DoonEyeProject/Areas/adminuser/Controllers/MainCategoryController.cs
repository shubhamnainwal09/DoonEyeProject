using DoonEyeProject.Areas.adminuser.Models;
using DoonEyeProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Areas.adminuser.Controllers
{
    public class MainCategoryController : Controller
    {

        string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        dbclass db = new dbclass();
        // GET: adminuser/MainCategory
        public ActionResult Index()
        {
            ViewBag.SuperList = db.ListAllSuperCategory();
            return View();
        }


        [HttpGet]
        public JsonResult List()
        {
            return Json(db.ListAllMainCategory(), JsonRequestBehavior.AllowGet);

        }


        [HttpPost]

        public JsonResult AddMain(Master_MainCategory m)
        {

            return Json(db.AddMainM(m), JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetbyID(int MainCategoryID)
        {
            var maincat = db.ListAllMainCategory().Find(x => x.MainCategoryID.Equals(MainCategoryID));
            return Json(maincat, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult update(Master_MainCategory m)
        {
            return Json(db.UpdateMain(m), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult delete(int MainCategoryID)
        {
            return Json(db.deletemain(MainCategoryID), JsonRequestBehavior.AllowGet);
        }


    }
}