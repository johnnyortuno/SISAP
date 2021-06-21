using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;

namespace SISAP.Core.Interfaces
{
    public interface IConsumoServicioService
    {
        IEnumerable<ConsumoServicio> GetAll();

        ConsumoServicio ObtenerConsumo(int ClienteId, int ServicioId, int PagoId);
    }
}
