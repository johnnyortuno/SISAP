using SISAP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Interfaces
{
	public interface ILecturaService
	{

		IEnumerable<Lectura> ValidateNullRow(int? Annio, int? Mes, int? UrbanizacionId);
		void UpdateLecturaProcesada(UpdateLecturaProcess updateLecturaProcess);
		IEnumerable<Cliente> ListLecturaMain(int? Annio, int? Mes, int? UrbanizacionId, string FilterNombre, int pageSize, int skip, out int nroTotalRegistros);
		IEnumerable<Lectura> ValidateNextYearUpdateLectura(int? Annio, int? Mes, int? UrbanizacionId);
		void UpdateProcessLectura(UpdateLectura updateLectura);
		IEnumerable<Lectura> CheckIfExistLectura(int? Annio, int? Mes, int? UrbanizacionId);
		IEnumerable<Lectura> ValidateValueNoNullable(int? Annio, int? Mes, int? UrbanizacionId);
		void UpdateDataExistLectura(Lectura objLectura);
		Lectura Create(Lectura objLectura);
		IEnumerable<Lectura> GetFirst6Data(int? ClienteId);
		IEnumerable<Cliente> ListarClienteLectura(int? Annio, int? Mes, int? UrbanizacionId, string FilterNombre, int pageSize, int skip, out int nroTotalRegistros);
	}
}
