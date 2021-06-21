using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SISAP.Core.Enum
{
    public enum ClaseCliente
    {
        [Description("Agua y Desague")]
        AguaD = 1,
        [Description("Agua")]
        Agua = 2,
        [Description("Desague")]
        Desague = 3,
    }
}
