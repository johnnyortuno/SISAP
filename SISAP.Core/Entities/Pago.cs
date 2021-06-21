using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISAP.Core.Entities
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int ClienteId { get; set; }
        public int EstadoPago { get; set; }
        public decimal? Total { get; set; }
        public int PeriodoAnnio { get; set; }
        public int PeriodoMes { get; set; }
        public DateTime? FechaPago { get; set; }
        public int? ServicioId { get; set; }
        public string Observaciones { get; set; }
        public string EstadoPagoDesc { get; set; }
        public int FacturacionId { get; set; }

        [NotMapped]
        public string FechaPagoStr { get; set; }

        [NotMapped]
        public string EstadoStr { get; set; }
        
        [NotMapped]
        public int CategoriaId { get; set; }

        [NotMapped]
        public string TipoCategoria { get; set; }

        [NotMapped]
        public string TotalPagar
        {
            get { return string.Format("S/." + this.Total); }
        }

    }
}
