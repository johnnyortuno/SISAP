using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
    public class Lectura
    {
        public int LecturaId { get; set; }
        public int Annio { get; set; }
        public int Mes { get; set; }
        public decimal? CantidadLectura { get; set; }
        public decimal? Consumo { get; set; }
        public decimal? Promedio { get; set; }
        public string Alerta { get; set; }
        public int ClienteId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal? CantidadLecturaAntigua { get; set; }
        public int Procesado { get; set; }
        public int Actualizado { get; set; }

        [NotMapped]
        public int FacturacionId { get; set; }

    }
}
