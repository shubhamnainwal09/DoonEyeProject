using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class Master_Country
    {

        public int CountryCode { get; set; }

        [Required(ErrorMessage ="*")]
        public string CountryName { get; set; }

        [Required(ErrorMessage ="*")]
        public string CountryInitial { get; set; }

        public string FlagUrl { get; set; }



    }
}