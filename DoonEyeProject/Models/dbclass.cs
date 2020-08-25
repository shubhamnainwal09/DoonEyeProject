using DoonEyeProject.Areas.adminuser.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Models
{
    public class dbclass
    {
        string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;


        //company list

        
        public List<Master_Company> ListAllCompany()
        {
            List<Master_Company> countries = new List<Master_Company>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_Company";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    countries.Add(new Master_Company
                    {
                        CompanyID = Convert.ToInt32(rdr["CompanyID"]),
                        CompanyName = rdr["CompanyName"].ToString(),
                        Address1 = rdr["Address1"].ToString(),

                        Address2 = rdr["Address2"].ToString(),
                        Tagline = rdr["Tagline"].ToString(),
                        Username = rdr["Username"].ToString(),

                        Password = rdr["Password"].ToString(),
                        LocalArea = rdr["LocalArea"].ToString(),
                        LogoUrl = rdr["LogoUrl"].ToString(),

                        CityCode = Convert.ToInt32(rdr["CityCode"]),
                        CompanyEmail = rdr["CompanyEmail"].ToString()
                       
                    });
                }
                return countries;
            }
        }

        //company add

        
        public int Addcompany(Master_Company c)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "insert into Master_Company(CompanyName,Address1,Address2,Tagline,LogoUrl,Username,Password,LocalArea,CityCode,CompanyEmail) values(@CompanyName, @Address1, @Address2, @Tagline, @LogoUrl, @Username, @Password, @LocalArea, @CityCode, @CompanyEmail)";
                SqlCommand com = new SqlCommand(q, con);

                //com.Parameters.AddWithValue("@CompanyID", c.CompanyID);
                com.Parameters.AddWithValue("@CompanyName", c.CompanyName);
                com.Parameters.AddWithValue("@Address1", c.Address1);

                com.Parameters.AddWithValue("@Address2", c.Address2);
                com.Parameters.AddWithValue("@Tagline", c.Tagline);
                com.Parameters.AddWithValue("@LogoUrl", c.LogoUrl);

                com.Parameters.AddWithValue("@Username", c.Username);
                com.Parameters.AddWithValue("@Password", c.Password);
                com.Parameters.AddWithValue("@LocalArea", c.LocalArea);

                com.Parameters.AddWithValue("@CityCode", c.CityCode);
                com.Parameters.AddWithValue("@CompanyEmail", c.CompanyEmail);
                
                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Country List
        public List<Master_Country> ListAll()
        {
            List<Master_Country> countries = new List<Master_Country>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_Country";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    countries.Add(new Master_Country
                    {
                        CountryCode = Convert.ToInt32(rdr["CountryCode"]),
                        CountryName = rdr["CountryName"].ToString(),
                        CountryInitial = (rdr["CountryInitial"].ToString())
                    });
                }
                return countries;
            }
        }


        //Country Add
        public int Add(Master_Country c)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "insert into Master_Country(CountryName,CountryInitial) values(@CountryName,@CountryInitial)";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@CountryName", c.CountryName);
                com.Parameters.AddWithValue("@CountryInitial", c.CountryInitial);
                i = com.ExecuteNonQuery();
            }
            return i;
        }



        //Method for Updating Country
        public int Update(Master_Country c)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "update Master_Country set CountryName=@CountryName,CountryInitial=@CountryInitial where CountryCode=@CountryCode";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@CountryCode", c.CountryCode);
                com.Parameters.AddWithValue("@CountryName", c.CountryName);
                com.Parameters.AddWithValue("@CountryInitial", c.CountryInitial);

                i = com.ExecuteNonQuery();
            }
            return i;
        }
        //Method for Deleting Country
        public int Delete(int CountryCode)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "delete from Master_Country where CountryCode=@CountryCode";
                SqlCommand com = new SqlCommand(q, con);

                com.Parameters.AddWithValue("@CountryCode", CountryCode);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Country And State Join List
        public List<CountryStateCity> ListCS()
        {
            List<CountryStateCity> countriesstate = new List<CountryStateCity>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_Country inner join Mater_State on Master_Country.CountryCode=Mater_State.CountryCode";

                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    countriesstate.Add(new CountryStateCity
                    {
                        CountryCode = Convert.ToInt32(rdr["CountryCode"]),
                        StateCode = Convert.ToInt32(rdr["StateCode"]),
                        CountryName = rdr["CountryName"].ToString(),
                        StateName = rdr["StateName"].ToString(),
                        CountryInitial = (rdr["CountryInitial"].ToString()),
                        StateInitial = (rdr["StateInitial"].ToString()),

                    });
                }
                return countriesstate;
            }
        }


        //Add State
        public int Add(Mater_State s)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "insert into Mater_State(StateCode,StateName,StateInitial,CountryCode) values(@StateCode,@StateName,@StateInitial,@CountryCode)";

                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@StateCode", s.StateCode);
                com.Parameters.AddWithValue("@StateName", s.StateName);
                com.Parameters.AddWithValue("@StateInitial", s.StateInitial);
                com.Parameters.AddWithValue("@CountryCode", s.CountryCode);
                i = com.ExecuteNonQuery();
            }
            return i;
        }




        //State List
        public List<Mater_State> Liststates()
        {
            List<Mater_State> states = new List<Mater_State>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Mater_State";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    states.Add(new Mater_State
                    {
                        StateCode = Convert.ToInt32(rdr["StateCode"]),
                        StateName = rdr["StateName"].ToString(),
                        StateInitial = (rdr["StateInitial"].ToString())
                    });
                }
                return states;
            }
        }

        //update state
        public int Updatestate(Mater_State s)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "update Mater_State set StateName=@StateName,StateInitial=@StateInitial where StateCode=@StateCode";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@StateCode", s.StateCode);
                com.Parameters.AddWithValue("@StateName", s.StateName);
                com.Parameters.AddWithValue("@StateInitial", s.StateInitial);


                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting State
        public int Deletestate(int StateCode)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "delete from Mater_State where StateCode=@StateCode";
                SqlCommand com = new SqlCommand(q, con);

                com.Parameters.AddWithValue("@StateCode", StateCode);
                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Country, State and City Join List
        public List<CountryStateCity> ListCSC()
        {
            List<CountryStateCity> countriesstatecity = new List<CountryStateCity>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_Country inner join Mater_State on Master_Country.CountryCode=Mater_State.CountryCode inner join Master_City on Mater_State.StateCode=Master_City.StateCode";

                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    countriesstatecity.Add(new CountryStateCity
                    {
                        CountryCode = Convert.ToInt32(rdr["CountryCode"]),
                        StateCode = Convert.ToInt32(rdr["StateCode"]),
                        CountryName = rdr["CountryName"].ToString(),
                        StateName = rdr["StateName"].ToString(),
                        CountryInitial = (rdr["CountryInitial"].ToString()),
                        StateInitial = (rdr["StateInitial"].ToString()),
                        CityCode = Convert.ToInt32(rdr["CityCode"]),
                        CityName = rdr["CityName"].ToString(),

                    });
                }
                return countriesstatecity;
            }
        }


        //Add City
        public int AddCity(Master_City c)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "insert into Master_City(CityCode,CityName,StateCode) values(@CityCode,@CityName,@StateCode)";

                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@CityCode", c.CityCode);
                com.Parameters.AddWithValue("@CityName", c.CityName);
                com.Parameters.AddWithValue("@StateCode", c.StateCode);
                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //update City
        public int Updatecity(Master_City c)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "update Master_City set  CityName=@CityName where CityCode=@CityCode";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@CityCode", c.CityCode);
                com.Parameters.AddWithValue("@CityName", c.CityName);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //CityList
        public List<Master_City> ListCity()
        {
            List<Master_City> states = new List<Master_City>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_City";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    states.Add(new Master_City
                    {
                        CityCode = Convert.ToInt32(rdr["CityCode"]),
                        CityName = rdr["CityName"].ToString()

                    });
                }
                return states;
            }
        }

        //Method for Deleting City
        public int Deletecity(int CityCode)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "delete from Master_City where CityCode=@CityCode";
                SqlCommand com = new SqlCommand(q, con);

                com.Parameters.AddWithValue("@CityCode", CityCode);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Country,State,City,Area Join List
        public List<CountryStateCity> ListCityArea()
        {
            List<CountryStateCity> countriesstatecityarea = new List<CountryStateCity>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_Country inner join Mater_State on Master_Country.CountryCode=Mater_State.CountryCode inner join Master_City on Mater_State.StateCode=Master_City.StateCode inner join Master_CityArea on Master_City.CityCode=Master_CityArea.CityCode";

                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    countriesstatecityarea.Add(new CountryStateCity
                    {
                        CountryCode = Convert.ToInt32(rdr["CountryCode"]),
                        StateCode = Convert.ToInt32(rdr["StateCode"]),
                        CountryName = rdr["CountryName"].ToString(),
                        StateName = rdr["StateName"].ToString(),
                        CountryInitial = (rdr["CountryInitial"].ToString()),
                        StateInitial = (rdr["StateInitial"].ToString()),
                        CityCode = Convert.ToInt32(rdr["CityCode"]),
                        CityName = rdr["CityName"].ToString(),
                        AreaCode = Convert.ToInt32(rdr["AreaCode"]),
                        AreaName = rdr["AreaName"].ToString()

                    });
                }
                return countriesstatecityarea;
            }
        }


        //Add CityArea
        public int AddCityArea(Master_CityArea ca)
        {
            int i;
            bool isnotValid = false;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select count(*) from Master_CityArea where AreaCode=@AreaCode";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@AreaCode", ca.AreaCode);
                isnotValid = (int)com.ExecuteScalar() > 0;
                if (isnotValid)
                {

                    i = 0;
                    return i;
                }

            }


            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "insert into Master_CityArea(AreaCode,AreaName,CityCode) values(@AreaCode,@AreaName,@CityCode)";

                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@AreaCode", ca.AreaCode);
                com.Parameters.AddWithValue("@AreaName", ca.AreaName);
                com.Parameters.AddWithValue("@CityCode", ca.CityCode);
                i = com.ExecuteNonQuery();
            }

            return i;
        }


        //update cityarea
        public int Updatecityarea(Master_CityArea a)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "update Master_CityArea set  AreaName=@AreaName where AreaCode=@AreaCode";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@AreaCode", a.AreaCode);
                com.Parameters.AddWithValue("@AreaName", a.AreaName);

                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Method for Deleting CityArea
        public int Deletecityarea(int AreaCode)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "delete from Master_CityArea where AreaCode=@AreaCode";
                SqlCommand com = new SqlCommand(q, con);

                com.Parameters.AddWithValue("@AreaCode", AreaCode);
                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //supercategory list

        //Country List
        public List<Master_SuperCategory> ListAllSuperCategory()
        {
            List<Master_SuperCategory> superc = new List<Master_SuperCategory>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_SuperCategory";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    superc.Add(new Master_SuperCategory
                    {
                        SuperCategoryID = Convert.ToInt32(rdr["SuperCategoryID"]),
                        SuperCategoryName = rdr["SuperCategoryName"].ToString(),
                        SuperCategoryDescription = (rdr["SuperCategoryDescription"].ToString()),
                        SuperCategoryIcon = (rdr["SuperCategoryIcon"].ToString())
                    });
                }
                return superc;
            }
        }


        //Add SuperCategory
        public int AddSuperC(Master_SuperCategory sc)
        {

            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
               
                    con.Open();
                    string q = "insert into Master_SuperCategory(SuperCategoryName,SuperCategoryDescription,SuperCategoryIcon) values(@SuperCategoryName,@SuperCategoryDescription,@SuperCategoryIcon)";

                    SqlCommand com = new SqlCommand(q, con);
                   // com.Parameters.AddWithValue("@SuperCategoryID", sc.SuperCategoryID);

                    com.Parameters.AddWithValue("@SuperCategoryName", sc.SuperCategoryName);
                    com.Parameters.AddWithValue("@SuperCategoryDescription", sc.SuperCategoryDescription);
                    com.Parameters.AddWithValue("@SuperCategoryIcon", sc.SuperCategoryIcon);
                    i = com.ExecuteNonQuery();
                    
               


                //try
                //{
                //    if (SuperCategoryIcon != null && SuperCategoryIcon.ContentLength > 0)
                //    {
                //        string filename = Path.GetFileName(SuperCategoryIcon.FileName);
                //        //string fileExtension = Path.GetExtension(filename);
                //        string imgpath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/SuperImages/"), filename);
                //        SuperCategoryIcon.SaveAs(imgpath);
                //    }
                //    com.Parameters.AddWithValue("@SuperCategoryIcon", "~/SuperImages/" + SuperCategoryIcon.FileName);
                //}

                //catch (Exception ex)
                //{

                //    return 0;



                //}

                return i;
                    
                }

               
               
            }



        //update SuperCategory
        public int UpdateSuper(Master_SuperCategory a)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "update Master_SuperCategory set SuperCategoryName=@SuperCategoryName, SuperCategoryDescription=@SuperCategoryDescription where SuperCategoryID=@SuperCategoryID";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@SuperCategoryID", a.SuperCategoryID);
                com.Parameters.AddWithValue("@SuperCategoryName", a.SuperCategoryName);
                com.Parameters.AddWithValue("@SuperCategoryDescription", a.SuperCategoryDescription);

                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //delete super

       
        public int deletesuper(int SuperCategoryID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "delete from Master_SuperCategory where SuperCategoryID=@SuperCategoryID";
                SqlCommand com = new SqlCommand(q, con);

                com.Parameters.AddWithValue("@SuperCategoryID", SuperCategoryID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }



        //main Category
        public List<Master_MainCategory> ListAllMainCategory()
        {
            List<Master_MainCategory> mainm = new List<Master_MainCategory>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_MainCategory";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    mainm.Add(new Master_MainCategory
                    {
                        SuperCategoryID = Convert.ToInt32(rdr["SuperCategoryID"]),
                        MainCategoryID = Convert.ToInt32(rdr["MainCategoryID"]),
                        MainCategoryname = rdr["MainCategoryname"].ToString(),
                        MainCategoryDes = (rdr["MainCategoryDes"].ToString()),
                       
                    });
                }
                return mainm;
            }
        }



        //add main category

        public int AddMainM(Master_MainCategory m)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "insert into Master_MainCategory(MainCategoryname,MainCategoryDes,SuperCategoryID) values(@MainCategoryname,@MainCategoryDes,@SuperCategoryID)";

                SqlCommand com = new SqlCommand(q, con);
               // com.Parameters.AddWithValue("@MainCategoryID", m.MainCategoryID);
                com.Parameters.AddWithValue("@MainCategoryname", m.MainCategoryname);
                com.Parameters.AddWithValue("@MainCategoryDes", m.MainCategoryDes);
                com.Parameters.AddWithValue("@SuperCategoryID", m.SuperCategoryID);

                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //update main category

        public int UpdateMain(Master_MainCategory a)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "update Master_MainCategory set MainCategoryname=@MainCategoryname,MainCategoryDes=@MainCategoryDes where MainCategoryID=@MainCategoryID";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@MainCategoryID", a.MainCategoryID);
                com.Parameters.AddWithValue("@MainCategoryname", a.MainCategoryname);
                com.Parameters.AddWithValue("@MainCategoryDes", a.MainCategoryDes);

                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //delete main

        public int deletemain(int MainCategoryID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "delete from Master_MainCategory where MainCategoryID=@MainCategoryID";
                SqlCommand com = new SqlCommand(q, con);

                com.Parameters.AddWithValue("@MainCategoryID", MainCategoryID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }




        //Sub Category
        public List<Master_SubCategory> ListAllSubCategory()
        {
            List<Master_SubCategory> subs = new List<Master_SubCategory>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "select *from Master_SubCategory";
                SqlCommand com = new SqlCommand(q, con);
                com.ExecuteNonQuery();
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    subs.Add(new Master_SubCategory
                    {
                        SubCategoryID = Convert.ToInt32(rdr["SubCategoryID"]),
                        MainCategoryID = Convert.ToInt32(rdr["MainCategoryID"]),
                        SubCategoryName = rdr["SubCategoryName"].ToString(),
                        SubCategoryDes = (rdr["SubCategoryDes"].ToString()),

                    });
                }
                return subs;
            }
        }



        //add sub category

        public int AddSubS(Master_SubCategory s)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "insert into Master_SubCategory(SubCategoryName,SubCategoryDes,MainCategoryID) values(@SubCategoryName,@SubCategoryDes,@MainCategoryID)";

                SqlCommand com = new SqlCommand(q, con);
                //com.Parameters.AddWithValue("@SubCategoryID", s.SubCategoryID);
                com.Parameters.AddWithValue("@SubCategoryName", s.SubCategoryName);
                com.Parameters.AddWithValue("@SubCategoryDes", s.SubCategoryDes);
                com.Parameters.AddWithValue("@MainCategoryID", s.MainCategoryID);

                i = com.ExecuteNonQuery();
            }
            return i;
        }



        //update Sub category

        public int UpdateSub(Master_SubCategory a)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "update Master_SubCategory set SubCategoryName=@SubCategoryName,SubCategoryDes=@SubCategoryDes where SubCategoryID=@SubCategoryID";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.AddWithValue("@SubCategoryID", a.SubCategoryID);
                com.Parameters.AddWithValue("@SubCategoryName", a.SubCategoryName);
                com.Parameters.AddWithValue("@SubCategoryDes", a.SubCategoryDes);

                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //delete Sub

        public int deletesub(int SubCategoryID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "delete from Master_SubCategory where SubCategoryID=@SubCategoryID";
                SqlCommand com = new SqlCommand(q, con);

                com.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }



    }

}
        

