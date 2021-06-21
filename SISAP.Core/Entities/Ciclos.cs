using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISAP.Core.Entities
{
	public class Ciclos
    {
        public int CiclosId { get; set; }
        public int Annio { get; set; }
        public int Mes { get; set; }
        public DateTime? LecturaInicial { get; set; }
        public DateTime? LecturaFinal { get; set; }
        public DateTime? EmisionInicial { get; set; }
        public DateTime? EmisionFinal { get; set; }
        public DateTime? DistribucionInicial { get; set; }
        public DateTime? DistribucionFinal { get; set; }
        public DateTime? CorteInicial { get; set; }
        public DateTime? CorteFinal { get; set; }


        [NotMapped]
        public string LecturaInicialStr { get; set; }

        [NotMapped]
        public string LecturaFinalStr { get; set; }

        [NotMapped]
        public string EmisionInicialStr { get; set; }

        [NotMapped]
        public string EmisionFinalStr { get; set; }

        [NotMapped]
        public string DistribucionInicialStr { get; set; }

        [NotMapped]
        public string DistribucionFinalStr { get; set; }

        [NotMapped]
        public string CorteInicialStr { get; set; }

        [NotMapped]
        public string CorteFinalStr { get; set; }

        public string NombreMes
        {
            get
            {
                var nombreMes = "";
                switch (Mes)
                {
                    case 1:
                        nombreMes = "Enero";
                        break;
                    case 2:
                        nombreMes = "Febrero";
                        break;
                    case 3:
                        nombreMes = "Marzo";
                        break;
                    case 4:
                        nombreMes = "Abril";
                        break;
                    case 5:
                        nombreMes = "Mayo";
                        break;
                    case 6:
                        nombreMes = "Junio";
                        break;
                    case 7:
                        nombreMes = "Julio";
                        break;
                    case 8:
                        nombreMes = "Agosto";
                        break;
                    case 9:
                        nombreMes = "Setiembre";
                        break;
                    case 10:
                        nombreMes = "Octubre";
                        break;
                    case 11:
                        nombreMes = "Noviembre";
                        break;
                    case 12:
                        nombreMes = "Diciembre";
                        break;
                }
                return nombreMes;
            }
        }
    }
}
