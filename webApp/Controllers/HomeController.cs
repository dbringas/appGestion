using BE.Seguridad;
using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using webApp.Models;

namespace webApp.Controllers
{
    public class HomeController : Controller
    {
        public String GetDatosSesion(String campo)
        {
            JavaScriptSerializer _serializer = new JavaScriptSerializer();
            List<Dictionary<String, Object>> listaPrivada = null;
            String valorCampo;

            try
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                String datoPrivado = authTicket.UserData;

                listaPrivada = _serializer.Deserialize<List<Dictionary<String, Object>>>(datoPrivado);

                Object _campoRequerido = null;

                foreach (Dictionary<String, Object> fila in listaPrivada)
                {
                    fila.TryGetValue(campo, out _campoRequerido);
                }

                valorCampo = _campoRequerido.ToString();
            }
            catch (Exception)
            {
                valorCampo = "";
            }

            return valorCampo;
        }

        public ActionResult _Navigation()
        {
            List<MenuViewModels> mensaje = new List<MenuViewModels>();
            MenuViewModels items;

            try
            {
                BL_usuarioMenu oData = new BL_usuarioMenu();
                usuariomenu beData = new usuariomenu();

                beData.inCodUsuario = Convert.ToInt32(GetDatosSesion("inCodUsuario"));

                List<Dictionary<String, Object>> lista = oData.getById(beData);

                foreach (Dictionary<String, Object> fila in lista)
                {
                    items = new MenuViewModels();

                    items.id = fila["id"].ToString();
                    items.padre = fila["parentid"].ToString();
                    items.hijos = Convert.ToInt32(fila["inNroHijos"].ToString());
                    items.area = fila["stArea"].ToString();
                    items.controlador = fila["stControlador"].ToString();
                    items.vista = fila["stVista"].ToString();
                    items.icono = fila["stIcono"].ToString();
                    items.nombre = fila["stNombre"].ToString();

                    mensaje.Add(items);
                }
            }
            catch (Exception)
            {
                mensaje = null;
            }

            return PartialView("_Navigation", mensaje);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}