using SISAP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Service
{
    public class OpcionService: _BaseContext
    {
        public List<Opcion> ListarOpciones()
        {
            using (var dbContext = GetSISAPDBContext())
            {
                var lista = (from o in dbContext.Opcions
                             select o).ToList();
                return lista;
            }
        }

    }
}


