using SISAP.Core.Entities;
using SISAP.Core.Enum;
using SISAP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Service
{
	public class PagoService : _BaseContext, IPagoService
	{
        public IEnumerable<Pago> GetPay(int? ClienteId, int pageSize, int skip, out int nroTotalRegistros)
        {
            using (var dbContest = GetSISAPDBContext())
            {
                var sql = (from p in dbContest.Pagos 
                           join c in dbContest.Clientes on p.ClienteId equals c.ClienteId into pc
                           from nc in pc.DefaultIfEmpty()
                           join cat in dbContest.Categorias on nc.CategoriaId equals cat.CategoriaId
                           join fa in dbContest.Facturacions on p.FacturacionId equals fa.FacturacionId
                           where nc.ClienteId == ClienteId
                                 && p.EstadoPago == (int)EstadoPay.Pagado
                           orderby fa.Mes descending
                           select new
                           {
                               p.PagoId,
                               p.PeriodoAnnio,
                               p.PeriodoMes,
                               cat.CategoriaId,
                               cat.TipoCategoria,
                               p.Total,
                               p.Observaciones,
                               EstadoStr = (p.EstadoPago == 1 ? "Pagado" : "Pendiente"),
                               p.FechaPago

                           });
                nroTotalRegistros = sql.Count();
                sql = sql.Skip(skip).Take(pageSize);
                var ListadoFinal = (from p in sql.ToList()
                                    select new Pago()
                                    {
                                        PagoId = p.PagoId,
                                        PeriodoAnnio = p.PeriodoAnnio,
                                        PeriodoMes = p.PeriodoMes,
                                        CategoriaId = p.CategoriaId,
                                        TipoCategoria = p.TipoCategoria,
                                        Total = p.Total,
                                        Observaciones = p.Observaciones,
                                        EstadoStr = p.EstadoStr,
                                        FechaPagoStr = string.Format("{0:dd/MM/yyyy}", p.FechaPago),

                                    }).ToList();
                return ListadoFinal;
            }
        }

        public Pago Pagar(Pago objPago)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                dbContext.Pagos.Add(objPago);
                dbContext.SaveChanges();

                var data = dbContext.Facturacions.First(f => f.Annio == objPago.PeriodoAnnio && f.Mes == objPago.PeriodoMes && f.ClienteId == objPago.ClienteId);

                data.EstadoPagado = objPago.EstadoPago;
                dbContext.SaveChanges();
            }
            return objPago;
        }

        public IEnumerable<Cliente> GetAllCF(int? UrbanizacionId, string FilterNombre, int pageSize, int skip, out int nroTotalRegistros)
		{
            using (var dbContext = GetSISAPDBContext())
            {
                var sql = (from c in dbContext.Clientes
                           join srv in dbContext.servicios on c.ServicioId equals srv.ServicioId
                           join cat in dbContext.Categorias on c.CategoriaId equals cat.CategoriaId
                           join u in dbContext.Urbanizacions on c.UrbanizacionId equals u.UrbanizacionId
                           join m in dbContext.Manzanas on c.ManzanaId equals m.ManzanaId
                           where (u.UrbanizacionId == UrbanizacionId || UrbanizacionId == null) &&
                                (string.IsNullOrEmpty(FilterNombre) || (c.Nombre + " " + c.Apellido + c.NumeroMedidor + "" + c.CodigoCliente + ""+c.DNI).Contains(FilterNombre.ToUpper()))
                           orderby c.Nombre ascending
                           select new
                           {
                               c.ClienteId,
                               c.UsuarioCreacion,
                               c.CodigoCliente,
                               c.Nombre,
                               c.Apellido,
                               c.DNI,
                               c.Telefono,
                               c.Direccion,
                               c.UrbanizacionId,
                               c.ManzanaId,
                               c.Complemento,
                               c.ServicioId,
                               c.CategoriaId,
                               c.NumeroMedidor,
                               c.EstadoServicioId,
                               c.Observaciones,
                               u.NombreUrbanizacion,
                               m.NombreManzana,
                               srv.ServicioNombre,
                               cat.TipoCategoria,
                               cat.ClaseId

                           });
                nroTotalRegistros = sql.Count();
                sql = sql.Skip(skip).Take(pageSize);

                var ListadoFinal = (from c in sql.ToList()
                                    select new Cliente()
                                    {
                                        ClienteId = c.ClienteId,
                                        CodigoCliente = c.CodigoCliente,
                                        Nombre = c.Nombre,
                                        Apellido = c.Apellido,
                                        DNI = c.DNI,
                                        Telefono = c.Telefono,
                                        Direccion = c.Direccion,
                                        UrbanizacionId = c.UrbanizacionId,
                                        ManzanaId = c.ManzanaId,
                                        ServicioId = c.ServicioId,
                                        CategoriaId = c.CategoriaId,
                                        Complemento = c.Complemento,
                                        NumeroMedidor = c.NumeroMedidor,
                                        EstadoServicioId = c.EstadoServicioId,
                                        UrbanizacionNombre = c.NombreUrbanizacion,
                                        ManzanaNombre = c.NombreManzana,
                                        Observaciones = c.Observaciones,
                                        ServicioNombre = c.ServicioNombre,
                                        TipoCategoria = c.TipoCategoria,
                                        ClaseId = c.ClaseId,

                                    }).ToList();
                return ListadoFinal;
            }
        }

		public IEnumerable<Facturacion> GetClienteDeudor(int? ClienteId, int pageSize, int skip, out int nroTotalRegistros)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from f in dbContext.Facturacions.Where(o => o.EstadoPagado != (int)EstadoPay.Pagado)
                           join c in dbContext.Clientes on f.ClienteId equals c.ClienteId
                           join serv in dbContext.servicios on c.ServicioId equals serv.ServicioId
                           join cat in dbContext.Categorias on c.CategoriaId equals cat.CategoriaId
						   where c.ClienteId == ClienteId
						   orderby f.Mes descending
                           select new
						   {
							   c.ClienteId,
							   f.FacturacionId,
                               c.Nombre,
                               c.Apellido,
                               f.Annio, 
							   f.Mes,
							   cat.CategoriaId,
							   cat.TipoCategoria,
							   serv.ServicioId,
							   serv.ServicioNombre,
							   f.Total,
                               f.EstadoPagado,
                               EstadoPagoDesc = (f.EstadoPagado == 1 ? "Pagado" : "Pendiente"),

                           });
				nroTotalRegistros = sql.Count();
				sql = sql.Skip(skip).Take(pageSize);
				var ListadoFinal = (from f in sql.ToList()
									select new Facturacion()
									{
                                        ClienteId = f.ClienteId,
                                        FacturacionId = f.FacturacionId,
                                        Annio = f.Annio,
                                        Mes = f.Mes,
                                        TipoCategoria = f.TipoCategoria,
                                        ServicioNombre = f.ServicioNombre,
                                        Total = f.Total,
                                        EstadoPagado = f.EstadoPagado,
                                        EstadoPagoDesc = f.EstadoPagoDesc,
                                        Nombre = f.Nombre,
                                        Apellido = f.Apellido

                                    }).ToList();
				return ListadoFinal;
			}
		}
	}
}
