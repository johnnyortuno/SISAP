using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Core.Entities
{
	public class Meses
	{
        public int MesesId { get; set; }
        public int Nombre { get; set; }

        public string NombreMes
        {
            get
            {
                var nombreMes = "";
                switch (Nombre)
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
