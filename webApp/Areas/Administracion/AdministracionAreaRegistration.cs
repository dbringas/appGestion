using System.Web.Mvc;

namespace webApp.Areas.Administracion
{
    public class AdministracionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administracion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administracion_default",
                "Administracion/{controller}/{action}/{id}",
                new { controller = "Administracion", action = "Proveedores", id = UrlParameter.Optional },
                namespaces: new string[] { "webApp.Areas.Administracion.Controllers" }
            );
        }
    }
}