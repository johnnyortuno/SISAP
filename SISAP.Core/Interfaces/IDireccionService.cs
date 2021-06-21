using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;

namespace SISAP.Core.Interfaces
{
    public interface IDireccionService
    {
        IEnumerable<Direccion> GetAll();
        IDireccionService ObtenerDireccion(string Manzana, string Lote, int ClienteId);
    }
}
