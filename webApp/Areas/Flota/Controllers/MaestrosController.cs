using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp.Areas.Flota.Controllers
{
    public class MaestrosController : Controller
    {
        public ActionResult Modelo()
        {
            return View();
        }

        public ActionResult Ata()
        {
            return View();
        }
    }
}