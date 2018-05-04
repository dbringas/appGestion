using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp.Areas.Inventario.Controllers
{
    public class MaestrosController : Controller
    {
        public ActionResult GrupoArticulo()
        {
            return View();
        }

        public ActionResult UnidadMedida()
        {
            return View();
        }
    }
}