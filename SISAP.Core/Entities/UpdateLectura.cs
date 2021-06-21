using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
	public class UpdateLectura
	{
		public int UpdateLecturaId { get; set; }
		public int Annio { get; set; }
		public int Mes { get; set; }
		public int ClienteId { get; set; }
		public Decimal? CantidadLecturaActualizar { get; set; }

	}
}
