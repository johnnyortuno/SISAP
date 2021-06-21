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
	public class ReportesService : _BaseContext, IReportesService
	{

		public decimal? getDeudaRuta(int? Annio, int? Mes, int? UrbanizacionId)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from c in dbContext.Clientes
						   join p in dbContext.Pagos on c.ClienteId equals p.ClienteId
						   join u in dbContext.Urbanizacions on c.UrbanizacionId equals u.UrbanizacionId
						   where p.PeriodoAnnio == Annio && p.PeriodoMes == Mes && u.UrbanizacionId == UrbanizacionId && p.EstadoPago == (int)EstadoPay.Pendiente
						   select p).Sum(p => p.Total);

				return sql;
			}
		}
		public decimal? getDeudaDistrito(int? Annio)
		{
			using (var dbContext = GetSISAPDBContext())
			{

				var total = dbContext.Pagos.Where(l=>l.PeriodoAnnio == Annio && l.EstadoPago == (int)EstadoPay.Pendiente).Sum(l => l.Total);

				return total;
			}
		}
		public decimal? getIngresoAnual(int? Annio)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var total = dbContext.Pagos.Where(l=>l.PeriodoAnnio == Annio && l.EstadoPago == (int)EstadoPay.Pagado).Sum(l => l.Total);

				return total;
			}
		}
		public decimal? getIngresoMensual(int? Annio, int? Mes)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var total = dbContext.Pagos.Where(l=>l.PeriodoAnnio == Annio && l.PeriodoMes == Mes && l.EstadoPago == (int)EstadoPay.Pagado).Sum(l => l.Total);

				return total;
			}
		}
		public decimal? getProcessLectura(int? Annio, int? Mes)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var total = dbContext.Lecturas.Where(l=>l.Annio == Annio && l.Mes == Mes).Sum(l => l.Consumo);

				return total;
			}
		}
	}
}
