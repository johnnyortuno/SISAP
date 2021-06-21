using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
	public class Tarifario
	{
		public int TarifarioId { get; set; }
		public int CategoriaId { get; set; }
		public decimal? RangoMin { get; set; }
		public decimal? RangoMax { get; set; }
		public decimal? TarifaAgua { get; set; }
		public decimal? TarifaAlcantarillado { get; set; }
		public decimal? CargoFijo { get; set; }
		public int ClaseId { get; set; }
		             
	}
}
