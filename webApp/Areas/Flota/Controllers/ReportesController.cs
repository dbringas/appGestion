using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp.Areas.Flota.Controllers
{
    public class ReportesController : Controller
    {
        public ActionResult Consultar()
        {
            return View();
        }

        public ActionResult SituacionFlota()
        {
            return View();
        }
    }
}