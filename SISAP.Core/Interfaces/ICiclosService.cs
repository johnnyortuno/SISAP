using SISAP.Core.Entities;
using System.Collections.Generic;

namespace SISAP.Core.Interfaces
{
	public interface ICiclosService
    {
        IEnumerable<Ciclos> EnableToNextPrecess(int? Annio, int? Mes);
        IEnumerable<Ciclos> ListarMesByAnnio(int? Annio);
        IEnumerable<Ciclos> ListarAnnios();
        void Update(Ciclos objCiclos);
        void Delete(int CiclosId);
        Ciclos Save(Ciclos objCiclos);
        IEnumerable<Ciclos> ListarCiclos(int pageSize, int skip, out int nroTotalRegistros);
    }
}
