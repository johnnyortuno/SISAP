using CrystalDecisions.CrystalReports.Engine;
using SISAP.Core.Entities;
using SISAP.Core.Enum;
using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISAP.Controllers
{
    public class PagosController : Controller
    {
        private readonly IPagoService _pagoService;

        public PagosController()
        {
            _pagoService = new PagoService();
        }
        // GET: Pagos
        public ActionResult Pagos()
        {
            return View();
        }
        public ActionResult PagosCliente()
        {
            return View();
        }
        public ActionResult PagosRecibo()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Pay(int? ClienteId)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var dPagos = _pagoService.GetPay(ClienteId, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = dPagos }, JsonRequestBehavior.AllowGet);
        }

       


        public ActionResult ReportePago(int id, int idCliente, string idPago)
        {
            #region "Generacion del Reporte"

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/ReportesCR"), "rptPagos.rpt"));
            rd.SetParameterValue("@usuarioId", id);
            rd.SetParameterValue("@clienteId", idCliente);
            rd.SetParameterValue("@pagoId", idPago);
            Response.Buffer = false;
            Response.ClearContent();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "pagos"+ idCliente + ".pdf");
            #endregion
        }
        public JsonResult Pagar(Pago objPago)
        {
            objPago.FechaPago = DateTime.Now;
            objPago.EstadoPago = (int)EstadoPay.Pagado;
            objPago.EstadoPagoDesc = "Pagado";
            //_pagoService.Pagar(objPago);
            // El resultado debera devolver un array que contenga todos los pagos realizados 
            // ejemplo [543] ejemplo2 [55,33,22,55] , etc 
            int[] res = new int[5];
            res[0] = 12;
            res[1] = 4;
            res[2] = 2;
            res[3] = 3;
            res[3] = 5;
            return Json(new { mensaje = res }, JsonRequestBehavior.AllowGet);
        }

 

        [HttpPost]
        public JsonResult ListPayByCliente(int? ClienteId)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var dPagos = _pagoService.GetClienteDeudor(ClienteId, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = dPagos }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ListMain(int? UrbanizacionId, string FilterNombre)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var dPagos = _pagoService.GetAllCF(UrbanizacionId, FilterNombre, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = dPagos }, JsonRequestBehavior.AllowGet);
        }
    }
}