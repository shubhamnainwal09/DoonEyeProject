using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class Master_SuperCategory
    {

       
        public int SuperCategoryID { get; set; }

       
        public string SuperCategoryName { get; set; }

        
        public string SuperCategoryDescription { get; set; }


        public string SuperCategoryIcon { get; set; }
    }
}