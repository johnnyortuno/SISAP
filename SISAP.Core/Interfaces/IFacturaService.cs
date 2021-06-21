using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;

namespace SISAP.Core.Interfaces
{
    public interface IFacturaService
    {
        IEnumerable<Facturacion> ListDetalleFacturacion(int? ClienteId, int pageSize, int skip, out int nroTotalRegistros);
        IEnumerable<Facturacion> ValidateIfExists(int? Annio, int? Mes, int? ClienteId);
        IEnumerable<Cliente> ListFactura(int? Annio, int? Mes, int? UrbanizacionId, string FilterNombre, int pageSize, int skip, out int nroTotalRegistros);
        void UpdateDataExistFactura(Facturacion objFactura);
        Facturacion Create(Facturacion objFactura);
    }
}
