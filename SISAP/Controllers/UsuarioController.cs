
using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Helper;
using SISAP.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISAP.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ListarUsuarios()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;
            var usuarios = _usuarioService.ListarUsuarios(pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal1 = nroTotalRegistros, data = usuarios }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RegistrarUsuarios()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarUsuario(Usuario objUsuario)
        {
            _usuarioService.Save(objUsuario);
            return Json(new { msg = "seccess" }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Update(Usuario objUsuario)
        {

            _usuarioService.Update(objUsuario);
            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);


        }
        public JsonResult Delete(int UsuarioId)
        {

            _usuarioService.Delete(UsuarioId);
            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);
        }


    }
}