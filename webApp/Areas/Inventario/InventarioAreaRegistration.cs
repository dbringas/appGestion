using System.Web.Mvc;

namespace webApp.Areas.Inventario
{
    public class InventarioAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Inventario";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Inventario_default",
                "Inventario/{controller}/{action}/{id}",
                new { controller = "Inventario", action = "Articulos", id = UrlParameter.Optional },
                namespaces: new string[] { "webApp.Areas.Inventario.Controllers" }
            );
        }
    }
}