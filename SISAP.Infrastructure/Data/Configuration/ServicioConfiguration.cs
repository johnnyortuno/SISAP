using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SISAP.Infrastructure.Data.Configuration
{
	class ServicioConfiguration : EntityTypeConfiguration<Servicio>
    {
        public ServicioConfiguration()
        {
            ToTable("Servicio", "dbo");
            HasKey(o => o.ServicioId);
        }
    }

}
