using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
    public class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        public int ConsumoServicioId { get; set; }
        public int ServicioId { get; set; }
        public string UsuarioCreacion { get; set; }
        public string Cantidad { get; set; }
        public string CostoCubo { get; set; }
        public string CostoRefacturacion { get; set; }
        public string CostoIGV { get; set; }
        public string CostoTotal { get; set; }


    }
}
