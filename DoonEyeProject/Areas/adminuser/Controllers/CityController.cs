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
    public class CityController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        dbclass db = new dbclass();
        // GET: adminuser/City
        public ActionResult Index()
        {
            ViewBag.CountryList = db.ListAll();
            ViewBag.StateList = db.Liststates();
            return View();
        }

        [HttpGet]
        public JsonResult Listcity()
        {
            return Json(db.ListCSC(), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetbyID(int CityCode)
        {
            var cities = db.ListCity().Find(x => x.CityCode.Equals(CityCode));
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Addcity(Master_City c)
        {
            return Json(db.AddCity(c), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getstatebyid(int CountryCode)
        {
            List<Mater_State> states = new List<Mater_State>();
            
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "select *from Mater_State where CountryCode=" + CountryCode;
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
                                states.Add(new Mater_State
                                {

                                    CountryCode = Convert.ToInt32(sdr["CountryCode"]),
                                    StateCode = Convert.ToInt32(sdr["StateCode"]),
                                    StateName = sdr["StateName"].ToString()

                                });

                            }
                        }

                    }
                }
                con.Close();
            }
            return Json(states, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Updatecity(Master_City c)
        {
            return Json(db.Updatecity(c), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deletecity(int CityCode)
        {
            return Json(db.Deletecity(CityCode), JsonRequestBehavior.AllowGet);
        }
    }
}