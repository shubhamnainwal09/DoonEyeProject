using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoonEyeProject.Areas.adminuser.Models
{
    public class Master_SubCategory
    {
        public int SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        public string SubCategoryDes { get; set; }

        public string SubCategorIcon { get; set; }

        public int MainCategoryID { get; set; }
    }
}