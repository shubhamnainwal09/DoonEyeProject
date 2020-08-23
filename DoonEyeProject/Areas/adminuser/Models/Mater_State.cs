using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class Mater_State
    {
        public int StateCode { get; set; }

        public string StateName { get; set; }

        public string StateInitial { get; set; }

        public int CountryCode { get; set; }
    }
}