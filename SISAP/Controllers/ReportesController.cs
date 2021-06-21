using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISAP.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IReportesService _reportesService;
        public ReportesController ()
		{
            _reportesService = new ReportesService();

        }
        // GET: Reportes
        public ActionResult Reportes()
        {
            return View();
        }
        public ActionResult ReportesDeudas()
        {
            return View();
        }
        public ActionResult ReportesDeudasDistrito()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeudaRuta(int? Annio, int? Mes, int? UrbanizacionId)
		{
             var cantidad = _reportesService.getDeudaRuta(Annio, Mes, UrbanizacionId);
            return Json(new { respuesta = cantidad }, JsonRequestBehavior.AllowGet);
		}
        
        [HttpPost]
        public JsonResult DeudaDistrito(int? Annio)
		{
             var cantidad = _reportesService.getDeudaDistrito(Annio);
            return Json(new { respuesta = cantidad }, JsonRequestBehavior.AllowGet);
		}
        
        [HttpPost]
        public JsonResult IngresosAnuales(int? Annio)
		{
             var cantidad = _reportesService.getIngresoAnual(Annio);
            return Json(new { respuesta = cantidad }, JsonRequestBehavior.AllowGet);
		}
                
        [HttpPost]
        public JsonResult IngresosMensuales(int? Annio, int? Mes)
		{
             var cantidad = _reportesService.getIngresoMensual(Annio, Mes);
            return Json(new { respuesta = cantidad }, JsonRequestBehavior.AllowGet);
		}
        
        [HttpPost]
        public JsonResult AllLecturas(int? Annio, int? Mes)
		{
             var cantidad = _reportesService.getProcessLectura(Annio, Mes);
            return Json(new { respuesta = cantidad }, JsonRequestBehavior.AllowGet);
		}
    }
}