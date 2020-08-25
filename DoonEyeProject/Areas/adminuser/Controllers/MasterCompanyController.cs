using DoonEyeProject.Areas.adminuser.Models;
using DoonEyeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Areas.adminuser.Controllers
{
    public class MasterCompanyController : Controller
    {
        dbclass db = new dbclass();
        // GET: adminuser/MasterCompany
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult List()
        {
            return Json(db.ListAllCompany(), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Add(Master_Company c)
        {
            
            
            return Json(db.Addcompany(c), JsonRequestBehavior.AllowGet);

        }

    }
}