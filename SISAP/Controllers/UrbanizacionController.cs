using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Helper;
using SISAP.Infrastructure.Service;

namespace SISAP.Controllers
{
    public class UrbanizacionController : Controller
    {

        //GET: Urbanizacion
        private readonly IUrbanizacionService _urbanizacionService;
        public UrbanizacionController()
        {
            _urbanizacionService = new UrbanizacionService();
        }
        public ActionResult Urbanizacion()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ListarUrbanizaciones()
        {
            var urbanizacion = SessionHelper.Get<string>("TipoUrbanizacion, Urbanizacion");
            var urbanizaciones = _urbanizacionService.GetAll();
            return Json(urbanizaciones, JsonRequestBehavior.AllowGet);
        }
    }
}