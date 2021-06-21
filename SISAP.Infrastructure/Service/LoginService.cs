using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Service
{
    public class LoginService : _BaseContext, ILoginService
    {

        public Usuario ValUserLogIn(string user, string password)
        {
            using (var dbContext = GetSISAPDBContext())
            {
                return dbContext.Usuarios.FirstOrDefault(o => o.usuario.Contains(user) && o.Password.Contains(password));
            }
        }
        public bool LogOut()
        {
            return true;
        }
    }
}
