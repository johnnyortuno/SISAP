using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Helper;
using SISAP.Infrastructure.Service;
using System;
using System.Web.Mvc;

namespace SISAP.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILoginService _loginService;
        public LoginController()
        {
            _usuarioService = new UsuarioService();
            _loginService = new LoginService();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        #region Login
        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            try
            {
                var u = _loginService.ValUserLogIn(user, password);
                if (u == null)
                {
                    ViewBag.Error = "Usuario y/o Contraseña Incorrecta";
                    return View();
                }
                var userData = _usuarioService.SingIn(user, password);
                SessionHelper.Set<int?>("UsuarioId", userData.UsuarioId);
                SessionHelper.Set<string>("usuario", userData.usuario);
                SessionHelper.Set<string>("Nombre", userData.Nombre);

                return Redirect(Url.Action("Inicio", "Inicio"));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }

        }
        #endregion

        #region LogOut
        public ActionResult LogOut()
        {
            try
            {
                SessionHelper.Set<int?>("UsuarioId", null);
                return Redirect(Url.Action("Login", "Login"));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
        #endregion
    }
}