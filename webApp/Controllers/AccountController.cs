using BE.Seguridad;
using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using webApp.Models;

namespace webApp.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModels model, string returnUrl)
        {
            JavaScriptSerializer _serializer = new JavaScriptSerializer();
            String mensaje = "";
            FormsAuthenticationTicket ticket;
            String encriptarTicket;
            HttpCookie cookieWeb;
            String informacion = "";
            Object _campoRequerido = null;

            if (ModelState.IsValid)
            {
                try
                {
                    BL_usuario oData = new BL_usuario();
                    usuario beData = new usuario();

                    beData.stCorreo = model.correo;
                    beData.stClave = model.clave;

                    String user = oData.getValidar(beData);

                    beData.inCodUsuario = Convert.ToInt32(user);

                    List<Dictionary<String, Object>> lista = oData.getById(beData);
                    
                    foreach (Dictionary<String, Object> fila in lista)
                    {
                        fila.TryGetValue("stNombre", out _campoRequerido);
                    }

                    // ------------------------------------------------------------------------------------------------------------------------------
                    // Cargar cookies con los datos de usuario logeado
                    // ------------------------------------------------------------------------------------------------------------------------------
                    informacion = _serializer.Serialize(lista);
                    ticket = new FormsAuthenticationTicket(1, _campoRequerido.ToString(), DateTime.Now, DateTime.Now.AddHours(3), false, informacion);

                    encriptarTicket = FormsAuthentication.Encrypt(ticket);
                    cookieWeb = new HttpCookie(FormsAuthentication.FormsCookieName, encriptarTicket);
                    cookieWeb.Path = FormsAuthentication.FormsCookiePath;
                    Response.Cookies.Add(cookieWeb);
                    // ------------------------------------------------------------------------------------------------------------------------------

                    return RedireccionarRuta(returnUrl);
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;

                    ModelState.AddModelError("", mensaje);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Registro()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registro(RegistroViewModels model)
        {
            if (ModelState.IsValid)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (model.correo != model.confirmarCorreo)
                            throw new Exception("Las cuentas de correo no coinciden.");

                        if (model.clave != model.confirmarClave)
                            throw new Exception("Las contraseñas no coinciden.");

                        scope.Complete();

                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();

                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
        
        private ActionResult RedireccionarRuta(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}