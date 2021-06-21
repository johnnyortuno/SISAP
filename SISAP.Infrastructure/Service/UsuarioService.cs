using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SISAP.Infrastructure.Service
{
    public class UsuarioService : _BaseContext, IUsuarioService
    {
        public IEnumerable<Usuario> GetAll()
        {
            using (var dbContext = GetSISAPDBContext())
            {
                return dbContext.Usuarios.OrderBy(o => o.UsuarioId).ToList();
            }
        }
        public IEnumerable<Usuario> ListarUsuarios(int pageSize, int skip, out int nroTotalRegistros)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                var sql = (from u in dbContext.Usuarios
                           orderby u.UsuarioId descending
                           select new
                           {

                               u.UsuarioId,
                               u.usuario,
                               u.Nombre,
                               u.Password,
                               u.Rol,
                               u.Estado
                           });
                nroTotalRegistros = sql.Count();
                sql = sql.Skip(skip).Take(pageSize);
                var ListFinal = (from c in sql.ToList()
                                 select new Usuario()
                                 {
                                     UsuarioId = c.UsuarioId,
                                     usuario = c.usuario,
                                     Nombre = c.Nombre,
                                     Password = c.Password,
                                     Rol = c.Rol,
                                     Estado = c.Estado

                                 }).ToList();
                return ListFinal;

            }
        }
        public Usuario SingIn(string user, string password)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                return dbContext.Usuarios.FirstOrDefault(u => u.usuario == user && u.Password == password);
            }
        }

        public Usuario Save(Usuario objUsuario)
        {
            using (var dbContex = GetSISAPDBContext())
            {
                dbContex.Usuarios.Add(objUsuario);
                dbContex.SaveChanges();

            }
            return objUsuario;

        }


        public void Update(Usuario objUsuario)
        {

            using (var dbContext = GetSISAPDBContext())
            {

                dbContext.Usuarios.Attach(objUsuario);
                dbContext.Entry(objUsuario).State = EntityState.Modified;
                dbContext.SaveChanges();

            }

        }



        public void Delete(int UsuarioId)
        {
            using (var dbContext = GetSISAPDBContext())
            {

                var usuarios = dbContext.Usuarios;
                var usuario = usuarios.FirstOrDefault(o => o.UsuarioId == UsuarioId);

                dbContext.Usuarios.Remove(usuario);
                dbContext.SaveChanges();

            }
        }




    }
}
