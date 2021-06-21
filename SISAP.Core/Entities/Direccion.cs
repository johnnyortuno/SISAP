using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
    public class Direccion
    { 
        public int DireccionId { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public int ClienteId { get; set; }
    }
}
