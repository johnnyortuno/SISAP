using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SISAP.Core.Entities;
using SISAP.Core.Enum;
using SISAP.Core.Interfaces;

namespace SISAP.Infrastructure.Service
{
    public class ClienteService : _BaseContext, IClienteService
    {

        public IEnumerable<Cliente> GetAll(string FilterNombre, string FilterCodigo, string FilterMedidor, int pageSize, int skip, out int nroTotalRegistros)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                var sql = (from c in dbContext.Clientes
                           join s in dbContext.EstadoServicios on c.EstadoServicioId equals s.EstadoServicioId
                           join u in dbContext.Urbanizacions on c.UrbanizacionId equals u.UrbanizacionId
                           join m in dbContext.Manzanas on c.ManzanaId equals m.ManzanaId
                           where
                                (string.IsNullOrEmpty(FilterNombre) || (c.Nombre + " " + c.Apellido + c.NumeroMedidor + "" + c.CodigoCliente).Contains(FilterNombre.ToUpper()))
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
                               s.EstadoDescripcion,
                               c.Observaciones,
                               u.NombreUrbanizacion,
                               m.NombreManzana

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
                                        EstadoServicio = new EstadoServicio()
                                        {
                                            EstadoServicioId = c.EstadoServicioId,
                                            EstadoDescripcion = c.EstadoDescripcion
                                        }

                                    }).ToList();
                return ListadoFinal;
            }
        }

        public IEnumerable<Cliente> GetById(int ClienteId)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                return dbContext.Clientes.Where(o => o.ClienteId == ClienteId).ToList();
            }
        }

        public Cliente Create(Cliente cliente)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                dbContext.Clientes.Add(cliente);
                dbContext.SaveChanges();
            }
            return cliente;
        }

        public void Update(Cliente cliente)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                dbContext.Clientes.Attach(cliente);
                dbContext.Entry(cliente).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int ClienteId)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                var clientes = dbContext.Clientes;
                var obj = clientes.FirstOrDefault(c => c.ClienteId == ClienteId);

                dbContext.Clientes.Remove(obj);
                dbContext.SaveChanges();
            }
        }
    }
}