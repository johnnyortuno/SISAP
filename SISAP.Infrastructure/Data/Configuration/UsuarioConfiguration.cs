using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SISAP.Infrastructure.Data.Configuration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario", "dbo");
            HasKey(o => o.UsuarioId);
        }
    }
}
