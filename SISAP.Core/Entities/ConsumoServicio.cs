using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
    public class ConsumoServicio
    {
        public int ConsumoServicioId { get; set; }
        public int ClienteId { get; set; }
        public int CategoriaId { get; set; }
        public int ServicioId { get; set; }
        public int PagoId { get; set; }

    }
}
