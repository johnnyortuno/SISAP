using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
	public class UpdateLecturaProcess
	{
		public int UpdateLecturaProcessId { get; set; }
		public int Annio { get; set; }
		public int Mes { get; set; }
		public int ClienteId { get; set; }
		public int Procesado { get; set; }
	}
}
