using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class Master_Company
    {

        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public int CityCode { get; set; }

        public string LocalArea { get; set; }

        public string LogoUrl { get; set; }

        public string Tagline { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string CompanyEmail { get; set; }
    }
}