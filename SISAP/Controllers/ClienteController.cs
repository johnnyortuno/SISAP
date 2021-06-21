using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISAP.Core.Entities;
using SISAP.Core.Enum;
using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Helper;
using SISAP.Infrastructure.Service;

namespace SISAP.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        private readonly IClienteService _clienteService;

        public ClienteController()
        {
            _clienteService = new ClienteService();

        }
        public ActionResult Clientes()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ListarClientes(string FilterNombre, string FilterCodigo, string FilterMedidor)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var clientes = _clienteService.GetAll(FilterNombre, FilterCodigo, FilterMedidor, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = clientes }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RegistrarClientes()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarCliente(Cliente objCliente) {

            _clienteService.Create(objCliente);

            return Json(new { msg ="success"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Cliente objCliente)
		{
            _clienteService.Update(objCliente);

            return Json( new { msg = "success" } , JsonRequestBehavior.AllowGet);
		}
        public JsonResult Delete(int ClienteId)
		{
            _clienteService.Delete(ClienteId);
            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);

        }
    }
}
