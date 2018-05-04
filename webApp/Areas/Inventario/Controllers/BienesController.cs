using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp.Areas.Inventario.Controllers
{
    public class BienesController : Controller
    {
        public ActionResult Articulos()
        {
            return View();
        }

        public ActionResult Lotes()
        {
            return View();
        }

        public ActionResult Series()
        {
            return View();
        }
    }
}