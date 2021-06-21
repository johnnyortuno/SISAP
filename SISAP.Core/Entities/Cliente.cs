
using System.ComponentModel.DataAnnotations.Schema;

namespace SISAP.Core.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string UsuarioCreacion { get; set; }
        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Complemento { get; set; }
        public int UrbanizacionId { get; set; }
        public int ManzanaId { get; set; }
        public int ServicioId { get; set; }
        public int CategoriaId { get; set; }
        public string NumeroMedidor { get; set; }
        public int EstadoServicioId { get; set; }
        public string Observaciones { get; set; }

        [NotMapped]
        public string UrbanizacionNombre { get; set; }
        
        [NotMapped]
        public string ServicioNombre { get; set; }
        
        [NotMapped]
        public string TipoCategoria { get; set; }        
        
        [NotMapped]
        public int ClaseId { get; set; }
                
        [NotMapped]
        public int PagoId { get; set; }
        
        [NotMapped]
        public string Estado { get; set; }
        
        [NotMapped]
        public string ObservacionesPago { get; set; }
        
        [NotMapped]
        public string FechaPago { get; set; }
        
        [NotMapped]
        public int EstadoInt { get; set; }
        

        [NotMapped]
        public string ManzanaNombre { get; set; }
        
        [NotMapped]
        public int LecturaId { get; set; }
        
        [NotMapped]
        public int FacturacionId { get; set; }
        
        [NotMapped]
        public int Annio { get; set; }
        
        [NotMapped]
        public int Mes { get; set; }
        
        [NotMapped]
        public decimal? CantidadLectura { get; set; }
        
        [NotMapped]
        public decimal? Consumo { get; set; }
        
        [NotMapped]
        public decimal? Promedio { get; set; }
        
        [NotMapped]
        public decimal? CantidadLecturaAntigua { get; set; }
        
        [NotMapped]
        public decimal? Total { get; set; }
        
        [NotMapped]
        public string Alerta { get; set; }

        public virtual EstadoServicio EstadoServicio { get; set; }


        [NotMapped]
        public string NombreCompleto
        {
            get { return string.Format("{0}, {1}", this.Apellido, this.Nombre); }
        }
        


        [NotMapped]
        public string DireccionStr
        {
            get { return string.Format("{0}, {1}, {2},{3}", "Urb. " + this.UrbanizacionNombre, "." + this.Complemento, "Mz." + this.ManzanaNombre, "Lt. " + this.Direccion); }
        }

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

    }
}
