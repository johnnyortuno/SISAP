using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;

namespace SISAP.Core.Interfaces
{
   public  interface ICategoriaService
    {
        IEnumerable<Categoria> GetAll();
        Categoria ListarCategoria(string CategoriaCodigo, string CategoriaTipo);
    }
}
