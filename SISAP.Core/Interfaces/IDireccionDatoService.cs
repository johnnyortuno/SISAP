using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;

namespace SISAP.Core.Interfaces
{
    public interface IDireccionDatoService
    {
        IEnumerable<DireccionDato> GetAll();
        IDireccionDatoService ObtenerDireccionDato(int DireccionDatoId, int ClienteId, int DireccionId, int UrbanizacionId);
    }
}
