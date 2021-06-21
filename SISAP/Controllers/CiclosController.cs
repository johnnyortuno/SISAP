using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISAP.Controllers
{
    public class CiclosController : Controller
    {
        private readonly ICiclosService ciclosService;

        public CiclosController()
        {
            ciclosService = new CiclosService();
        }

        public ActionResult Ciclos()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarCiclos(Ciclos objCiclos)
        {
            ciclosService.Save(objCiclos);
            return Json(new { ok = "ok" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Ciclos objCiclos)
		{
            ciclosService.Update(objCiclos);
            return Json(new { ok = "success" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Delete(int CiclosId)
		{
            ciclosService.Delete(CiclosId);
            return Json(new { ok = "success" }, JsonRequestBehavior.AllowGet);
		}

        [HttpPost]
        public JsonResult ListarCiclos()
		{
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var ciclos = ciclosService.ListarCiclos(pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = ciclos }, JsonRequestBehavior.AllowGet);
        }
    }
}