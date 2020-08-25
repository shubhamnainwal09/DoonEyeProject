using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class Master_MainCategory
    {
        public int MainCategoryID { get; set; }

        public string MainCategoryname { get; set; }

        public string MainCategoryDes {get;set;}

        public string MainCategoryIcon { get; set; }

        public int SuperCategoryID { get; set; }
    }
}