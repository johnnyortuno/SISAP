using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SISAP.Infrastructure.Data.Configuration
{
	class EstadoServicioConfiguration : EntityTypeConfiguration<EstadoServicio>
    {
        public EstadoServicioConfiguration()
    {
        ToTable("EstadoServicio", "dbo");
        HasKey(o => o.EstadoServicioId);
    }
}
}
