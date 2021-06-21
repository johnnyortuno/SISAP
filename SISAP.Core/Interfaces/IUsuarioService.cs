using SISAP.Core.Entities;
using System.Collections.Generic;

namespace SISAP.Core.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario SingIn(string user, string password);
        void Update(Usuario objUsuario);
        void Delete(int UsuarioId);
        Usuario Save(Usuario objUsuario);
        IEnumerable<Usuario> ListarUsuarios(int pageSize, int skip, out int nroTotalRegistros);
    }
}
