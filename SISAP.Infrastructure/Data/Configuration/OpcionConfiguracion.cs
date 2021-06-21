using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SISAP.Infrastructure.Data.Configuration
{
    public class OpcionConfiguracion : EntityTypeConfiguration<Opcion>
    {
        public OpcionConfiguracion()
        {
            ToTable("Opcion", "dbo");
            HasKey(o => o.OpcionId);
        }
    }
}
