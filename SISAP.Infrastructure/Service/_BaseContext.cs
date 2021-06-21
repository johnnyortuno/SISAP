using SISAP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Service
{
    public class _BaseContext
    {
        public SISAPDBContext GetSISAPDBContext()
        {
            return new SISAPDBContext();
        }
    }
}
