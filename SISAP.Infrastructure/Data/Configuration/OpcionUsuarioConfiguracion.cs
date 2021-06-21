using SISAP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Data.Configuration
{
    public class OpcionUsuarioConfiguracion : EntityTypeConfiguration<OpcionUsuario>
    {
        public OpcionUsuarioConfiguracion()
        {
            ToTable("OpcionUsuario", "dbo");
            HasKey(o => o.OpcionUsuarioId);
        }
    }
}
