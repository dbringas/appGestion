using System.Web.Mvc;

namespace webApp.Areas.Flota
{
    public class FlotaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Flota";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Flota_default",
                "Flota/{controller}/{action}/{id}",
                new { controller = "Flota", action = "Consultar", id = UrlParameter.Optional },
                namespaces: new string[] { "webApp.Areas.Flota.Controllers" }
            );
        }
    }
}