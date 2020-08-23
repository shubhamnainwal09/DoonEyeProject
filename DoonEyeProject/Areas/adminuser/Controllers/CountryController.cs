using DoonEyeProject.Areas.adminuser.Models;
using DoonEyeProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Areas.adminuser.Controllers
{
    public class CountryController : Controller
    {
        dbclass db = new dbclass(); 
       // GET: adminuser/Country
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
             return Json(db.ListAll(), JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public JsonResult Add(Master_Country c)
        {
            //if (!ModelState.IsValid)
            //{
            //return Json(new { success = false, issue = c, errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
            //}
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Country");
            return Json(db.Add(c), JsonRequestBehavior.AllowGet);

        }

       
    public JsonResult GetbyID(int CountryCode)
        {
            var country = db.ListAll().Find(x => x.CountryCode.Equals(CountryCode));
            return Json(country, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult update(Master_Country c)
        {
            return Json(db.Update(c), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult delete(int CountryCode)
        {
            return Json(db.Delete(CountryCode), JsonRequestBehavior.AllowGet);
        }
    }
}