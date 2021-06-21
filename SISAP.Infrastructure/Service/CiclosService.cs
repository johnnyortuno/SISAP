using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SISAP.Infrastructure.Service
{
	public class CiclosService : _BaseContext, ICiclosService
	{
		public IEnumerable<Ciclos> EnableToNextPrecess(int? Annio, int? Mes)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				int? NextMonth = Mes + 2;
				//return dbContext.Ciclos.Where(c => c.Annio == Annio && c.Mes > Mes && (c.Mes <NextMonth)).ToList();
				var sql = (from c in dbContext.Ciclos
						   where c.Annio > Annio
						   select c).ToList();
				int nroAnnio = sql.Count();
				if (nroAnnio > 0)
				{
					return dbContext.Ciclos.Where(c => c.Annio > Annio).ToList();

				}
				else
				{
					return dbContext.Ciclos.Where(c => c.Annio == Annio && c.Mes > Mes && (c.Mes < NextMonth)).ToList();

				}
			}
		}

		public Ciclos Save(Ciclos objCiclos)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				dbContext.Ciclos.Add(objCiclos);
				dbContext.SaveChanges();
			}
			return objCiclos;
		}

		public void Update(Ciclos objCiclos)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				dbContext.Ciclos.Attach(objCiclos);
				dbContext.Entry(objCiclos).State = EntityState.Modified;
				dbContext.SaveChanges();
			}
		}

		public void Delete(int CiclosId)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var ciclos = dbContext.Ciclos;
				var ciclo = ciclos.FirstOrDefault(o => o.CiclosId == CiclosId);

				dbContext.Ciclos.Remove(ciclo);
				dbContext.SaveChanges();
			}
		}

		public IEnumerable<Ciclos> ListarCiclos(int pageSize, int skip, out int nroTotalRegistros)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from c in dbContext.Ciclos
						   orderby c.CiclosId descending
						   select new
						   {
							   c.CiclosId,
							   c.Annio,
							   c.Mes,
							   c.LecturaInicial,
							   c.LecturaFinal,
							   c.EmisionInicial,
							   c.EmisionFinal,
							   c.DistribucionInicial,
							   c.DistribucionFinal,
							   c.CorteInicial,
							   c.CorteFinal
						   });

				nroTotalRegistros = sql.Count();
				sql = sql.Skip(skip).Take(pageSize);

				var ListFinal = (from c in sql.ToList()
								select new Ciclos()
								{
									CiclosId = c.CiclosId,
									Annio = c.Annio,
									Mes = c.Mes,
									LecturaInicialStr = string.Format("{0:dd/MM/yyyy}", c.LecturaInicial),
									LecturaFinalStr = string.Format("{0:dd/MM/yyyy}", c.LecturaFinal),
									EmisionInicialStr = string.Format("{0:dd/MM/yyyy}", c.EmisionInicial),
									EmisionFinalStr = string.Format("{0:dd/MM/yyyy}", c.EmisionFinal),
									DistribucionInicialStr = string.Format("{0:dd/MM/yyyy}", c.DistribucionInicial),
									DistribucionFinalStr = string.Format("{0:dd/MM/yyyy}", c.DistribucionFinal),
									CorteInicialStr = string.Format("{0:dd/MM/yyyy}", c.CorteInicial),
									CorteFinalStr = string.Format("{0:dd/MM/yyyy}", c.CorteFinal)
								}).ToList();

				return ListFinal;

			}
		}

		public IEnumerable<Ciclos> ListarAnnios()
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from c in dbContext.Ciclos
						   select new
						   {
							   c.CiclosId,
							   c.Annio
						   }).ToList().Select(o => new Ciclos()
						   {
							   CiclosId = o.CiclosId,
							   Annio = o.Annio
						   });
				return sql.ToList();
			}
		}

		
		public IEnumerable<Ciclos> ListarMesByAnnio(int? Annio)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from c in dbContext.Ciclos
						   where Annio == c.Annio
						   select new
						   {
							   c.CiclosId,
							   c.Annio,
							   c.Mes
						   }).ToList().Select(o => new Ciclos()
						   {
							   CiclosId = o.CiclosId,
							   Annio = o.Annio,
							   Mes = o.Mes
						   });
				return sql.ToList();
			}
		}
		
	}
}
