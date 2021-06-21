using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISAP.Transfer
{
    public partial class usuariodt
    { 
        public int idUsuario { get; set; }
        public int codigo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int documento { get; set; }
        public int telefono { get; set; }
        public int ruta { get; set; }
        public string manzana { get; set; }
        public string lote { get; set; }
        public string urbanizacion { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public string servicio { get; set; }
        public string categoria { get; set; }
        public string estado { get; set; }
        public string nromedidor { get; set; }
        public DateTime fechaconex { get; set; }
        public DateTime fehcacese { get; set; }
        public string observaciones { get; set; }

    }
}