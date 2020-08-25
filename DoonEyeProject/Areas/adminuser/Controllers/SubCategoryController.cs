using DoonEyeProject.Areas.adminuser.Models;
using DoonEyeProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Areas.adminuser.Controllers
{
    public class SubCategoryController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        dbclass db = new dbclass();
        // GET: adminuser/SubCategory
        public ActionResult Index()
        {
            ViewBag.SuperList = db.ListAllSuperCategory();
            
            return View();
        }

        [HttpGet]
        public JsonResult ListSub()
        {
            return Json(db.ListAllSubCategory(), JsonRequestBehavior.AllowGet);

        }


        [HttpPost]

        public JsonResult AddSub(Master_SubCategory s)
        {

            return Json(db.AddSubS(s), JsonRequestBehavior.AllowGet);

        }


        public JsonResult getmainbyid(int SuperCategoryID)
        {
            List<Master_MainCategory> maincat = new List<Master_MainCategory>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "select *from Master_MainCategory where SuperCategoryID=" + SuperCategoryID;
                using (SqlCommand cmd = new SqlCommand(q))
                {
                    cmd.Connection = con;

                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                maincat.Add(new Master_MainCategory
                                {

                                    SuperCategoryID = Convert.ToInt32(sdr["SuperCategoryID"]),
                                    MainCategoryID = Convert.ToInt32(sdr["MainCategoryID"]),
                                    MainCategoryname = sdr["MainCategoryname"].ToString()

                                });

                            }
                        }

                    }
                }
                con.Close();
            }
            return Json(maincat, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetbyID(int SubCategoryID)
        {
            var sc = db.ListAllSubCategory().Find(x => x.SubCategoryID.Equals(SubCategoryID));
            return Json(sc, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult update(Master_SubCategory sc)
        {
            return Json(db.UpdateSub(sc), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult delete(int SubCategoryID)
        {
            return Json(db.deletesub(SubCategoryID), JsonRequestBehavior.AllowGet);
        }



    }
}