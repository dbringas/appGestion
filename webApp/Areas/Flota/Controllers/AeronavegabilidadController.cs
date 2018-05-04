using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp.Areas.Flota.Controllers
{
    public class AeronavegabilidadController : Controller
    {
        public ActionResult Aeronaves()
        {
            return View();
        }

        public ActionResult Contadores()
        {
            return View();
        }

        public ActionResult ComponentesCompuestos()
        {
            return View();
        }
        
        public ActionResult ComponentesInstalados()
        {
            return View();
        }

        public ActionResult ContadorAeronave()
        {
            return View();
        }

        public ActionResult ContadorComponente()
        {
            return View();
        }

        public ActionResult PropiedadComponente()
        {
            return View();
        }
    }
}