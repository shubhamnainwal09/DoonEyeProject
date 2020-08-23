using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class Master_City
    {
        [Required(ErrorMessage ="*")]
        public int CityCode { get; set; }

        [Required(ErrorMessage = "*")]
        public string CityName { get; set; }

        public int StateCode { get; set; }

    }
}