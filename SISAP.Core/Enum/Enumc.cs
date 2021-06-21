using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SISAP.Core.Enum
{
   public enum CategoriaCliente
    {
        [Description("Social")]
        Social = 1,
        [Description("Domestico")]
        Domestico = 2,
        [Description("Comercial")]
        Comercial = 3,
        [Description("Industrial")]
        Industrial = 4,
        [Description("Estatal")]
        Estatal = 5,
    }
}
