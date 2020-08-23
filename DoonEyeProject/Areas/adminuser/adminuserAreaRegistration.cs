using System.Web.Mvc;

namespace DoonEyeProject.Areas.adminuser
{
    public class adminuserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "adminuser";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "adminuser_default",
                "adminuser/{controller}/{action}/{id}",
                new {Controller="Country", action = "Index", id = UrlParameter.Optional }
                
            );
        }
    }
}