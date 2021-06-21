using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISAP.Controllers
{
    public class ConfiguracionController : Controller
    {
        // GET: Configuracion
        public ActionResult Configuracion()
        {
            return View();
        }
        public ActionResult Roles()
        {
            return View();
        }
        public ActionResult Permisos()
        {
            return View();
        }
        public ActionResult Perfil()
        {
            return View();
        }
       
    }
}