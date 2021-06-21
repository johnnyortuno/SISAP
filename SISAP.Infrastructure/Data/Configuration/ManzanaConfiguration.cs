using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SISAP.Infrastructure.Data.Configuration
{
	public class ManzanaConfiguration : EntityTypeConfiguration<Manzana>
    {
        public ManzanaConfiguration()
        {
            ToTable("Manzana", "dbo");
            HasKey(o => o.ManzanaId);
        }
    }
}
