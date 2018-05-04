using System.Web.Mvc;

namespace webApp.Areas.Seguridad
{
    public class SeguridadAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Seguridad";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Seguridad_default",
                "Seguridad/{controller}/{action}/{id}",
                new { controller = "Seguridad", action = "Perfil", id = UrlParameter.Optional },
                namespaces: new string[] { "webApp.Areas.Seguridad.Controllers" }
            );
        }
    }
}