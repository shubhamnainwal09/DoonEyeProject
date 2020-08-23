using DoonEyeProject.Areas.adminuser.Models;
using DoonEyeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Areas.adminuser.Controllers
{
    public class StateController : Controller
    {

        dbclass db = new dbclass();
        // GET: adminuser/State
        public ActionResult Index()
        {
            ViewBag.CountryList = db.ListAll();
            return View();
        }

        [HttpGet]
        public JsonResult Liststate()
        {
            return Json(db.ListCS(), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Addstate(Mater_State s)
        {
            return Json(db.Add(s), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetbyID(int StateCode)
        {
            var states = db.Liststates().Find(x => x.StateCode.Equals(StateCode));
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Updatestate(Mater_State s)
        {
            return Json(db.Updatestate(s), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deletestate(int StateCode)
        {
            return Json(db.Deletestate(StateCode), JsonRequestBehavior.AllowGet);
        }
    }
}