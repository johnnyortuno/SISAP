using SISAP.Core.Entities;
using SISAP.Core.Enum;
using SISAP.Core.Interfaces;
using SISAP.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISAP.Controllers
{
    public class LecturaController : Controller
    {
        private readonly ILecturaService _lecturaService;
        private readonly ICiclosService _ciclosService;
        private readonly ITarifarioService _tarifarioService;
        private readonly IClienteService _clienteService;
        private readonly IFacturaService _facturaService;

        public LecturaController()
		{
            _lecturaService = new LecturaService();
            _ciclosService = new CiclosService();
            _tarifarioService = new TarifarioService();
            _clienteService = new ClienteService();
            _facturaService = new FacturaService();
		}
        // GET: Lectura
        public ActionResult Lectura()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListLecturaMain(int? Annio, int? Mes, int? UrbanizacionId, string FilterNombre)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var lecturas = _lecturaService.ListLecturaMain(Annio, Mes, UrbanizacionId, FilterNombre, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = lecturas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProcessLectura(ValidateLectura objValidate)
		{
            int Annio = objValidate.Annio;
            int Mes = objValidate.Mes;
            int UrbanizacionId = objValidate.UrbanizacionId;

            int newY = Annio;
            int newM = Mes + 1;

            var dataNextYar = _lecturaService.ValidateNextYearUpdateLectura(Annio, Mes, UrbanizacionId);
            var existNextYear = dataNextYar.Count();
            var dataFromLecturaActually = _lecturaService.ValidateValueNoNullable(Annio, Mes, UrbanizacionId);
            if(existNextYear >0)
			{
                newM = newM - 12;
                newY = Annio + 1;
			}
            decimal? value = 0;
            int ClienteId = 0;

            foreach (var item in dataFromLecturaActually)
			{
                value = item.CantidadLectura;
                ClienteId = item.ClienteId;

                var updateLectura = new UpdateLectura()
                {
                    Annio = newY,
                    Mes = newM,
                    ClienteId = ClienteId,
                    CantidadLecturaActualizar = value
                };

                _lecturaService.UpdateProcessLectura(updateLectura);
            }

            return Json(new { mensaje = "success"}, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult ExistLectura(ValidateLectura objValidate)
		{
            int Annio = objValidate.Annio;
            int Mes = objValidate.Mes;
            int UrbanizacionId = objValidate.UrbanizacionId;
            
            var dato = _lecturaService.CheckIfExistLectura(Annio, Mes, UrbanizacionId);
            var nroRegistros = dato.Count();
            
            return Json(new { mensaje = nroRegistros }, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public JsonResult ProcesarLectura(ValidateLectura objValidate)
		{
            int Annio = objValidate.Annio;
            int Mes = objValidate.Mes;
            int UrbanizacionId = objValidate.UrbanizacionId;
            
            var output = "";
            var datos = _ciclosService.EnableToNextPrecess(Annio, Mes);
            var datosnullable = _lecturaService.ValidateNullRow(Annio, Mes, UrbanizacionId);

            if (datos.Count() == 0)
			{
                output = "10";
			} 
            /*else if(datosnullable.Count() != 0)
			{
                output = "15";
			} */
            else 
			{
                int nextM = 0;
                int nextY = 0;
                decimal? cantAntigua = 0;
                var netxtYM = _ciclosService.EnableToNextPrecess(Annio, Mes);
                foreach (var item in netxtYM)
                {
                    nextY = item.Annio;
                    nextM = item.Mes;
                }
                int? ClienteId = 0;
                var objLectura = _lecturaService.ValidateValueNoNullable(Annio, Mes, UrbanizacionId);
                foreach (var item in objLectura)
                {
                    var updateLecturaProcess = new UpdateLecturaProcess()
                    {
                        Annio = Annio,
                        Mes = Mes,
                        ClienteId = item.ClienteId,
                        Procesado = 1
                    };
                    _lecturaService.UpdateLecturaProcesada(updateLecturaProcess);

                    cantAntigua = item.CantidadLectura;
                    item.CantidadLecturaAntigua = cantAntigua;
                    item.Annio = nextY;
                    item.Mes = nextM;
                    item.CantidadLectura = 0;
                    item.Consumo = 0;
                    item.Promedio = 0;
                    item.FechaRegistro = DateTime.Now;
                    item.Actualizado = 0;
                    _lecturaService.Create(item);

                }
                output = "success";
			}
            
            return Json(new { msg = output }, JsonRequestBehavior.AllowGet);

		}
        [HttpPost]
        public JsonResult ValidateEnableNextMonth(int? Annio, int? Mes)
		{

            var datos = _ciclosService.EnableToNextPrecess(Annio, Mes);
            var count = datos.Count();
            return Json(new { mensaje = count }, JsonRequestBehavior.AllowGet);
		}

        [HttpPost]
        public JsonResult ValidateNullableRow(ValidateLectura objValidate)
		{
            int Annio = objValidate.Annio;
            int Mes = objValidate.Mes;
            int UrbanizacionId = objValidate.UrbanizacionId;
            var datos = _lecturaService.ValidateValueNoNullable(Annio, Mes, UrbanizacionId);
            var msg = 0;
            foreach(var item in datos)
			{
                if(item.CantidadLectura == 0)
				{
                    msg = 1;
				}
			}
            return Json(new { mensaje = msg }, JsonRequestBehavior.AllowGet);
		}

        //EN MODIFICACION
        [HttpPost]
        public JsonResult UpdateDataExistLectura(Lectura objLectura)
		{
            int ClienteId = objLectura.ClienteId;
            var top6 = _lecturaService.GetFirst6Data(ClienteId);
            var top6Count = top6.Count();
            var consumo = objLectura.CantidadLectura - objLectura.CantidadLecturaAntigua;
            objLectura.Consumo = consumo;
            objLectura.FechaRegistro = DateTime.Now;
            decimal? c = 0;

            if(top6Count >5)
			{
                foreach(var items in top6)
				{
                    var value = items.Consumo;
                    c += value;
				}

                objLectura.Promedio = (c / 6);
			}
            _lecturaService.UpdateDataExistLectura(objLectura);

            var dataExist = _facturaService.ValidateIfExists(objLectura.Annio, objLectura.Mes, ClienteId);
            var FacturacionId = 0;
            foreach(var item in dataExist)
			{
                FacturacionId = item.FacturacionId;
			}
            var cliente = _clienteService.GetById(ClienteId);
            var tarifario = _tarifarioService.getTarifario();

            int CategoriaId = 0;
            int ServicioId = 0;
            foreach (var item in cliente)
            {
                CategoriaId = item.CategoriaId;
                ServicioId = item.ServicioId;
            }
            decimal? CargoFijo = 0;
            foreach (var item in tarifario)
            {
                if (CategoriaId == item.CategoriaId)
                {
                    CargoFijo = item.CargoFijo;
                }
            }
            //Reglas de negocio

            if (dataExist.Count() !=0)
			{
                if (CategoriaId == (int)CategoriaCliente.Social)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {

                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.2),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.2))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.2)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.1))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.2)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.1)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);

                        }
                    }
                }
                else if (CategoriaId == (int)CategoriaCliente.Domestico)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 25)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.3),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.3))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(25.00) && objLectura.CantidadLectura <= Convert.ToDecimal(30.00))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.4),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.4))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.10))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.5),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.5))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 25)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.3)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.3)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(25.00) && objLectura.CantidadLectura <= Convert.ToDecimal(30.00))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.4)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.4)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.10))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.5)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.3))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.5)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.3)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                    }


                }
                else if (CategoriaId == (int)CategoriaCliente.Comercial)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 30)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.1))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.80))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 30)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.1))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30))),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                    }

                }
                else if (CategoriaId == (int)CategoriaCliente.Industrial)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(1.0))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.4))),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.4)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                    }
                }
                else if (CategoriaId == (int)CategoriaCliente.Estatal)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.3))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                FacturacionId = FacturacionId,
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.1))),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.1)))
                            };
                            _facturaService.UpdateDataExistFactura(objFacturacion);
                        }
                    }
                }
            } else
			{

                if (CategoriaId == (int)CategoriaCliente.Social)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {

                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.2),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.2))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.2)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.1))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.2)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.1)))
                            };
                            _facturaService.Create(objFacturacion);

                        }
                    }
                }
                else if (CategoriaId == (int)CategoriaCliente.Domestico)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 25)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.3),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.3))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(25.00) && objLectura.CantidadLectura <= Convert.ToDecimal(30.00))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.4),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.4))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.10))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.5),
                                Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.5))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 25)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.3)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.3)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2)))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(25.00) && objLectura.CantidadLectura <= Convert.ToDecimal(30.00))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.4)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.4)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2)))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.10))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.5)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.3))),
                                Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.5)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.3)))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                    }


                }
                else if (CategoriaId == (int)CategoriaCliente.Comercial)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 30)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70))
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.1))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.80))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 30)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)))
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.1))
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30))),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)))
                            };
                            _facturaService.Create(objFacturacion);
                        }
                    }

                }
                else if (CategoriaId == (int)CategoriaCliente.Industrial)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(1.0))
                            };
                            _facturaService.Create(objFacturacion);
                        }

                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.4))),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.4)))
                            };
                            _facturaService.Create(objFacturacion);
                        }
                    }
                }
                else if (CategoriaId == (int)CategoriaCliente.Estatal)
                {
                    if (ServicioId == (int)Servicios.Agua)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)),
                                Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.3))
                            };
                            _facturaService.Create(objFacturacion);
                        }
                    }
                    else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                    {
                        //START
                        if (objLectura.CantidadLectura < 1)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = CargoFijo,
                                Total = CargoFijo
                            };
                            _facturaService.Create(objFacturacion);
                        }
                        else if (objLectura.CantidadLectura > 0)
                        {
                            var objFacturacion = new Facturacion()
                            {
                                ClienteId = ClienteId,
                                Annio = objLectura.Annio,
                                Mes = objLectura.Mes,
                                SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.1))),
                                Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.1)))
                            };
                            _facturaService.Create(objFacturacion);
                        }
                    }
                }

            }

            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);


        }
        //EN MODIFICACION
        [HttpPost]
        public JsonResult SaveFirstDataLectura(Lectura objLectura)
		{

            int ClienteId = objLectura.ClienteId;
            var top6 = _lecturaService.GetFirst6Data(ClienteId);
            var top6Count = top6.Count();
            var fecchaRegistro = DateTime.Now;
            var consumo = objLectura.CantidadLectura - objLectura.CantidadLecturaAntigua;
            objLectura.Consumo = consumo;
            objLectura.FechaRegistro = fecchaRegistro;
            decimal? c = 0;
            if(top6Count >5)
			{
                foreach(var items in top6)
				{
                    var value = items.Consumo;
                    c += value;
				}

                objLectura.Promedio = (c / 6);
			}

            _lecturaService.Create(objLectura);

            var cliente = _clienteService.GetById(ClienteId);
            var tarifario = _tarifarioService.getTarifario();

            int CategoriaId = 0;
            int ServicioId = 0;
            foreach (var item in cliente)
            {
                CategoriaId = item.CategoriaId;
                ServicioId = item.ServicioId;
            }
            decimal? CargoFijo = 0;
            foreach(var item in tarifario)
			{
                if(CategoriaId == item.CategoriaId)
				{
                    CargoFijo = item.CargoFijo;
                }
            }
            //Reglas de negocio

            if (CategoriaId == (int)CategoriaCliente.Social)
            {
                if (ServicioId == (int)Servicios.Agua)
                {
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0)
                    {

                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.2),
                            Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.2))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                }
                else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                {
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }

                    else if (objLectura.CantidadLectura > 0)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.2)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.1))),
                            Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.2)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.1)))
                        };
                        _facturaService.Create(objFacturacion);

                    }
                }
            }
            else if (CategoriaId == (int)CategoriaCliente.Domestico)
            {
                if (ServicioId == (int)Servicios.Agua)
                {
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <=25)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.3),
                            Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.3))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                    else if (objLectura.CantidadLectura >= Convert.ToDecimal(25.00) && objLectura.CantidadLectura <= Convert.ToDecimal(30.00))
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.4),
                            Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.4))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                    else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.10))
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = objLectura.CantidadLectura * Convert.ToDecimal(0.5),
                            Total = (objLectura.CantidadLectura * Convert.ToDecimal(0.5))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                }
                else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                {
                    //START
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <=25)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.3)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2))),
                            Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.3)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2)))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                    else if (objLectura.CantidadLectura >= Convert.ToDecimal(25.00) && objLectura.CantidadLectura <= Convert.ToDecimal(30.00))
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.4)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2))),
                            Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.4)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.2)))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                    else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.10))
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura * Convert.ToDecimal(0.5)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.3))),
                            Total = ((objLectura.CantidadLectura * Convert.ToDecimal(0.5)) + (objLectura.CantidadLectura * Convert.ToDecimal(0.3)))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                }


            }
            else if (CategoriaId == (int)CategoriaCliente.Comercial)
            {
                if (ServicioId == (int)Servicios.Agua)
                {
                    //START
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 30)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)),
                            Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70))
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.1))
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)),
                            Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.80))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                }
                else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                {
                    //START
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0 && objLectura.CantidadLectura <= 30)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)),
                            Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.70)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)))
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura >= Convert.ToDecimal(30.1))
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30))),
                            Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.80)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.30)))
                        };
                        _facturaService.Create(objFacturacion);
                    }
                }

            }
            else if (CategoriaId == (int)CategoriaCliente.Industrial)
            {
                if (ServicioId == (int)Servicios.Agua)
                {
                    //START
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)),
                            Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(1.0))
                        };
                        _facturaService.Create(objFacturacion);
                    }

                }
                else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                {
                    //START
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.4))),
                            Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(1.0)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.4)))
                        };
                        _facturaService.Create(objFacturacion);
                    }
                }
            }
            else if (CategoriaId == (int)CategoriaCliente.Estatal)
            {
                if (ServicioId == (int)Servicios.Agua)
                {
                    //START
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)),
                            Total = ((objLectura.CantidadLectura) * Convert.ToDecimal(0.3))
                        };
                        _facturaService.Create(objFacturacion);
                    }
                }
                else if (ServicioId == (int)Servicios.AguaAlcantarillado)
                {
                    //START
                    if (objLectura.CantidadLectura < 1)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = CargoFijo,
                            Total = CargoFijo
                        };
                        _facturaService.Create(objFacturacion);
                    }
                    else if (objLectura.CantidadLectura > 0)
                    {
                        var objFacturacion = new Facturacion()
                        {
                            ClienteId = ClienteId,
                            Annio = objLectura.Annio,
                            Mes = objLectura.Mes,
                            SubTotal = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.1))),
                            Total = (((objLectura.CantidadLectura) * Convert.ToDecimal(0.3)) + ((objLectura.CantidadLectura) * Convert.ToDecimal(0.1)))
                        };
                        _facturaService.Create(objFacturacion);
                    }
                }
            }

            return Json(new { msg = "success" }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult ListaLecturaByFilters(int? Annio, int?Mes, int? UrbanizacionId, string FilterNombre)
		{
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int nroTotalRegistros = 0;

            var lecturas = _lecturaService.ListarClienteLectura(Annio, Mes, UrbanizacionId, FilterNombre, pageSize, skip, out nroTotalRegistros);

            return Json(new { draw = draw, recordsFiltered = nroTotalRegistros, recordsTotal = nroTotalRegistros, data = lecturas }, JsonRequestBehavior.AllowGet);
        }
    }
}