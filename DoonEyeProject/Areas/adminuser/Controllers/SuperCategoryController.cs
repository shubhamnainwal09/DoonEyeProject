using DoonEyeProject.Areas.adminuser.Models;
using DoonEyeProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Areas.adminuser.Controllers
{
    public class SuperCategoryController : Controller
    {

        string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        dbclass db = new dbclass();
        string fname;
        // GET: adminuser/SuperCategory
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            return Json(db.ListAllSuperCategory(), JsonRequestBehavior.AllowGet);

        }


       [HttpPost]

        public JsonResult AddSuper(Master_SuperCategory sc)
        {
            HttpPostedFileBase file = Request.Files[0]; //Uploaded file                                 
            int fileSize = file.ContentLength;
            string fileName = file.FileName;
            string filePath = "/SuperImages/" + fileName;
            file.SaveAs(Server.MapPath(filePath));
            string mimeType = file.ContentType;
            System.IO.Stream fileContent = file.InputStream;
            //To save file, use SaveAs method
            //fname = Path.Combine(Server.MapPath("~/SuperImages/" + fileName));
            //file.SaveAs(fname); //File will be saved in application root
            //sc.SuperCategoryIcon = fname;
            sc.SuperCategoryIcon = filePath;
            return Json(db.AddSuperC(sc), JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetbyID(int SuperCategoryID)
        {
            var sc = db.ListAllSuperCategory().Find(x => x.SuperCategoryID.Equals(SuperCategoryID));
            return Json(sc, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult update(Master_SuperCategory sc)
        {
            return Json(db.UpdateSuper(sc), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult delete(int SuperCategoryID)
        {
            return Json(db.deletesuper(SuperCategoryID), JsonRequestBehavior.AllowGet);
        }

    }
}
