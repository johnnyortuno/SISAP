using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SISAP.Infrastructure.Service
{
	public class UrbanizacionService : _BaseContext, IUrbanizacionService
    {
		public Urbanizacion Create(Urbanizacion objUrbanizacion)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				dbContext.Urbanizacions.Add(objUrbanizacion);
				dbContext.SaveChanges();
			}
			return objUrbanizacion;
		}
		public Manzana CreateManzana(Manzana objManzana)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				dbContext.Manzanas.Add(objManzana);
				dbContext.SaveChanges();
			}
			return objManzana;
		}

		public void UpdateUrbanizacion(Urbanizacion objUrbanizacion)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				dbContext.Urbanizacions.Attach(objUrbanizacion);
				dbContext.Entry(objUrbanizacion).State = EntityState.Modified;
				dbContext.SaveChanges();
			}
		}
		
		public void UpdateManzana(Manzana objManzana)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				dbContext.Manzanas.Attach(objManzana);
				dbContext.Entry(objManzana).State = EntityState.Modified;
				dbContext.SaveChanges();
			}
		}

		public void DeleteUrbanizacion(int UrbanizacionId)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var urbanizacions = dbContext.Urbanizacions;
				var id = urbanizacions.FirstOrDefault(c => c.UrbanizacionId == UrbanizacionId);

				dbContext.Urbanizacions.Remove(id);
				dbContext.SaveChanges();
			}
		}
		
		public void DeleteManzana(int ManzanaId)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var manzanas = dbContext.Manzanas;
				var id = manzanas.FirstOrDefault(c => c.ManzanaId == ManzanaId);

				dbContext.Manzanas.Remove(id);
				dbContext.SaveChanges();
			}
		}

		public IEnumerable<Urbanizacion> GetAll()
		{
			using (var dbContext = GetSISAPDBContext())
			{
				return dbContext.Urbanizacions.OrderBy(u => u.UrbanizacionId).ToList();
			}
		}

		public IEnumerable<Manzana> GetManzanaByUrbanizacionId(int UrbanizacionId)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from m in dbContext.Manzanas
						   join u in dbContext.Urbanizacions on m.UrbanizacionId equals u.UrbanizacionId
						   where m.UrbanizacionId == UrbanizacionId
						   select m).ToList();
				return sql;
			}
		}

		public IEnumerable<Urbanizacion> GetUrbByUrbanizacionNombre(string NombreUrbanizacion, int pageSize, int skip, out int nroTotalRegistros)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from u in dbContext.Urbanizacions
						   where string.IsNullOrEmpty(NombreUrbanizacion) || u.NombreUrbanizacion.Contains(NombreUrbanizacion.ToUpper())
						   orderby u.UrbanizacionId

						   select new
						   {
							   u.UrbanizacionId,
							   u.NombreUrbanizacion,
							   u.Codigo
						   });
				nroTotalRegistros = sql.Count();
				sql = sql.Skip(skip).Take(pageSize);
				var ListFinal = (from c in sql.ToList()
								 select new Urbanizacion()
								 {
									 UrbanizacionId = c.UrbanizacionId,
									 NombreUrbanizacion = c.NombreUrbanizacion,
									 Codigo = c.Codigo
								 }).ToList();
				return ListFinal;

			}
		}
		
		public IEnumerable<Manzana> GetUrbByManzanaNombre(string NombreManzana, int pageSize, int skip, out int nroTotalRegistros)
		{
			using (var dbContext = GetSISAPDBContext())
			{
				var sql = (from m in dbContext.Manzanas
						   join u in dbContext.Urbanizacions on m.UrbanizacionId equals u.UrbanizacionId
						   where string.IsNullOrEmpty(NombreManzana) || m.NombreManzana.Contains(NombreManzana.ToUpper())
						   orderby m.ManzanaId

						   select new
						   {
							   m.ManzanaId,
							   m.UrbanizacionId,
							   m.NombreManzana,
							   u.NombreUrbanizacion
						   });
				nroTotalRegistros = sql.Count();
				sql = sql.Skip(skip).Take(pageSize);
				var ListFinal = (from c in sql.ToList()
								 select new Manzana()
								 {
									 ManzanaId = c.ManzanaId,
									 UrbanizacionId = c.UrbanizacionId,
									 NombreManzana = c.NombreManzana,
									 NombreUrbanizacion = c.NombreUrbanizacion

								 }).ToList();
				return ListFinal;

			}
		}

		public IEnumerable<Servicio> GetAllServicios()
		{
			using (var dbContext = GetSISAPDBContext())
			{
				return dbContext.servicios.OrderBy(o => o.ServicioId).ToList();
			}
		}

		public IEnumerable<Categoria> GetAllCategoria()
		{
			using (var dbContext = GetSISAPDBContext())
			{
				return dbContext.Categorias.OrderBy(o => o.CategoriaId).ToList();
			}
		}

		public IEnumerable<EstadoServicio> GetListEstadoServicio()
		{
			using (var dbContext = GetSISAPDBContext())
			{
				return dbContext.EstadoServicios.OrderBy(o => o.EstadoServicioId).ToList();
			}
		}
	}
    
}

