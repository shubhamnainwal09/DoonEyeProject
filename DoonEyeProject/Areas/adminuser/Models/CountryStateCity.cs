using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class CountryStateCity
    {
        public int CountryCode { get; set; }
        
        public string CountryName { get; set; }

        public string CountryInitial { get; set; }

        public string FlagUrl { get; set; }

        public int StateCode { get; set; }

        public string StateName { get; set; }

        public string StateInitial { get; set; }

        public int CityCode { get; set; }

        public string CityName { get; set; }

        public int AreaCode { get; set; }

        public string AreaName { get; set; }


    }
}