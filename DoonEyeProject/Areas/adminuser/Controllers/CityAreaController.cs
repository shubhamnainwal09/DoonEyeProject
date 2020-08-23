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
    public class CityAreaController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        dbclass db = new dbclass();
        // GET: adminuser/CityArea
        public ActionResult Index()
        {
            ViewBag.CountryList = db.ListAll();
            return View();
        }

        //getstate
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


        //getcity
        public JsonResult getcitybyid(int StateCode)
        {
            List<Master_City> cities = new List<Master_City>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "select *from Master_City where StateCode=" + StateCode;
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
                                cities.Add(new Master_City
                                {

                                    StateCode = Convert.ToInt32(sdr["StateCode"]),
                                    CityCode = Convert.ToInt32(sdr["CityCode"]),
                                    CityName = sdr["CityName"].ToString()

                                });

                            }
                        }

                    }
                }
                con.Close();
            }
            return Json(cities, JsonRequestBehavior.AllowGet);

        }


        //cityAreaList
        [HttpGet]
        public JsonResult Listcityarea()
        {
            return Json(db.ListCityArea(), JsonRequestBehavior.AllowGet);

        }


        //Add City Area
        [HttpPost]
        public JsonResult Addcityarea(Master_CityArea ca)
        {
            return Json(db.AddCityArea(ca), JsonRequestBehavior.AllowGet);
        }

        //Check Area Code
        //[HttpPost]
        //public JsonResult CheckUsername(int AreaCode)
        //{
        //    int r = 0;
        //    bool isValid = true;
           
               
        //        using (SqlConnection con = new SqlConnection(cs))
        //        {
        //            con.Open();
        //            string q = "select count(*) from Master_CityArea where AreaCode=@AreaCode";
                     
        //            SqlCommand com = new SqlCommand(q, con);
        //            com.Parameters.AddWithValue("@AreaCode", AreaCode);
        //            r = (int)com.ExecuteScalar();
        //        if (r > 0)
        //        {
        //            isValid = false;
        //        }
                    
                 
        //    }

        //    return Json(isValid, JsonRequestBehavior.AllowGet);
        //}
    }
}