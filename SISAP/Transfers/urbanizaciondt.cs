using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISAP.Transfers
{
    public partial class urbanizaciondt
    {
        public int idUrbanizacion { get; set; }
        public int codigo { get; set; }
        public string tipo { get; set; }
        public string calles { get; set; }
        public string manzana { get; set; }
        public string lote { get; set; }
        public int ltenumero { get; set; }

    }
}