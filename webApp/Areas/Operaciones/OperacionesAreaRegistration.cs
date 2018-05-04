using System.Web.Mvc;

namespace webApp.Areas.Operaciones
{
    public class OperacionesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Operaciones";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Operaciones_default",
                "Operaciones/{controller}/{action}/{id}",
                new { controller = "Operaciones", action = "Estaciones", id = UrlParameter.Optional },
                namespaces: new string[] { "webApp.Areas.Operaciones.Controllers" }
            );
        }
    }
}