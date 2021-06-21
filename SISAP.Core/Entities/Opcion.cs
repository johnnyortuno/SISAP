using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
    public class Opcion
    {
        public int OpcionId { get; set; }
        public string Etiqueta { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public int? Orden { get; set; }
        public string Icono { get; set; }
        public string  CreadoPor { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
