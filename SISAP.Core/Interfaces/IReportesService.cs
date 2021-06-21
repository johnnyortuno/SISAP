using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Interfaces
{
	public interface IReportesService
	{
		decimal? getDeudaDistrito(int? Annio);
		decimal? getDeudaRuta(int? Annio, int? Mes, int? UrbanizacionId);
		decimal? getIngresoAnual(int? Annio);
		decimal? getIngresoMensual(int? Annio, int? Mes);
		decimal? getProcessLectura(int? Annio, int? Mes);
	}
}
