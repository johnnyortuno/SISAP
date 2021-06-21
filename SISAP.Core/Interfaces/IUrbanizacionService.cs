using SISAP.Core.Entities;
using System.Collections.Generic;

namespace SISAP.Core.Interfaces
{
	public interface IUrbanizacionService
    {
        void DeleteManzana(int ManzanaId);
        void UpdateManzana(Manzana objManzana);
        IEnumerable<Manzana> GetUrbByManzanaNombre(string NombreManzana, int pageSize, int skip, out int nroTotalRegistros);
        Manzana CreateManzana(Manzana objManzana);
        void DeleteUrbanizacion(int UrbanizacionId);
        void UpdateUrbanizacion(Urbanizacion objUrbanizacion);
        IEnumerable<Urbanizacion> GetUrbByUrbanizacionNombre(string NombreUrbanizacion, int pageSize, int skip, out int nroTotalRegistros);
        Urbanizacion Create(Urbanizacion objUrbanizacion);
        IEnumerable<Urbanizacion> GetAll();
        IEnumerable<Manzana> GetManzanaByUrbanizacionId(int UrbanizacionId);
        IEnumerable<Servicio> GetAllServicios();
        IEnumerable<Categoria> GetAllCategoria();
        IEnumerable<EstadoServicio> GetListEstadoServicio();
    }
}
