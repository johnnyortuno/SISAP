using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
	public class Facturacion
	{
		public int FacturacionId { get; set; }
		public int ClienteId { get; set; }
		public int Annio { get; set; }
		public int Mes { get; set; }
		public decimal? SubTotal { get; set; }
		public decimal? Total { get; set; }
		public int? NroBoleta { get; set; }
		public DateTime? FechaEmision { get; set; }
		public int? EstadoPagado { get; set; }

		[NotMapped]
		public string Periodo
		{
			get { return string.Format("{0} - {1}", this.Mes, this.Annio); }
		}
		[NotMapped]
		public string TotalPagar
		{
			get { return string.Format("S/." + this.Total); }
		}

		[NotMapped]
		public string EstadoPagoDesc { get; set; }

		[NotMapped]
		public string TipoCategoria { get; set; }
		
		[NotMapped]
		public string ServicioNombre { get; set; }
		
		[NotMapped]
		public string Nombre { get; set; }
		
		[NotMapped]
		public string Apellido { get; set; }

		[NotMapped]
		public string NombreCompleto
		{
			get { return string.Format("{0}, {1}", this.Apellido, this.Nombre); }
		}


	}
}
