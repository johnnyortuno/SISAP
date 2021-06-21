using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Service;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SISAP.Controllers
{
	public class CommonController : Controller
    {
        private readonly IUrbanizacionService _commonService;
        private readonly ICiclosService _ciclosService;
        

        public CommonController()
		{
            _commonService = new UrbanizacionService();
            _ciclosService = new CiclosService();
        }


        [HttpPost]
        public JsonResult ListAnnio()
		{
            var annio = _ciclosService.ListarAnnios();

            var resultado = annio.GroupBy(a => new { Value = a.Annio, Text = a.Annio }).
                Select(a => new { Value = a.Key.Value, Text = a.Key.Text }).OrderByDescending(o => o.Value).ToList();
            return Json(resultado, JsonRequestBehavior.AllowGet);
		}
        
        [HttpPost]
        public JsonResult ListMes(int? Annio)
		{
            var mes = _ciclosService.ListarMesByAnnio(Annio);

            var resultado = mes.GroupBy(m => new { Month = m.Mes, NombreMes = m.NombreMes }).
                Select(m => new { Value = m.Key.Month, Text = m.Key.NombreMes }).ToList();
            return Json(resultado, JsonRequestBehavior.AllowGet);
		}


        [HttpPost]
        public JsonResult ListarUrbanizacion()
		{
            var urbanizacions = _commonService.GetAll();
            return Json(urbanizacions, JsonRequestBehavior.AllowGet);
		}
        [HttpPost]
        public JsonResult ListarUrbanizacionByNombre(string NombreUrbanizacion)
		{
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var urbanizacions = _commonService.GetUrbByUrbanizacionNombre(NombreUrbanizacion, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = urbanizacions }, JsonRequestBehavior.AllowGet);

		}
        
        [HttpPost]
        public JsonResult ListarManzanaByNombre(string NombreManzana)
		{
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var manzanas = _commonService.GetUrbByManzanaNombre(NombreManzana, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = manzanas }, JsonRequestBehavior.AllowGet);

		}

        [HttpPost]
        public JsonResult UpdateUrbanizacion(Urbanizacion objUrbanizacion)
		{
            _commonService.UpdateUrbanizacion(objUrbanizacion);
            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult updateManzana(Manzana objManzana)
		{
            _commonService.UpdateManzana(objManzana);
            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteUrbanizacion(int UrbanizacionId)
		{
            _commonService.DeleteUrbanizacion(UrbanizacionId);
            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult DeleteManzana(int ManzanaId)
		{
            _commonService.DeleteManzana(ManzanaId);
            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarManzana(int UrbanizacionId)
		{
            var manzanas = _commonService.GetManzanaByUrbanizacionId(UrbanizacionId);
            return Json(manzanas, JsonRequestBehavior.AllowGet);
		}
        
        [HttpPost]
        public JsonResult ListarServicios()
		{
            var servicios = _commonService.GetAllServicios();
            return Json(servicios, JsonRequestBehavior.AllowGet);
		}

        [HttpPost]
        public JsonResult ListarCategoria()
		{
            var categorias = _commonService.GetAllCategoria();
            return Json(categorias, JsonRequestBehavior.AllowGet);
		}
        [HttpPost]
        public JsonResult ListarEstadoServicio()
		{
            var eServicio = _commonService.GetListEstadoServicio();

            return Json(eServicio, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveUrbanizacion(Urbanizacion objUrbanizacion)
		{
            _commonService.Create(objUrbanizacion);
            return Json(new { ok = "ok" }, JsonRequestBehavior.AllowGet);
		}
        
        [HttpPost]
        public JsonResult SaveManzana(Manzana objManzana)
		{
            _commonService.CreateManzana(objManzana);
            return Json(new { ok = "ok" }, JsonRequestBehavior.AllowGet);
		}

    }
}