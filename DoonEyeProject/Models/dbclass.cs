using DoonEyeProject.Areas.adminuser.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoonEyeProject.Models
{
    public class dbclass
    {
        string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;


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
                com.Parameters.AddWithValue("@AreaCode",ca.AreaCode);
                isnotValid = (int)com.ExecuteScalar()>0;
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

    }

}