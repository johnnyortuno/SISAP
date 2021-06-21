
using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;


namespace SISAP.Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("Cliente", "dbo");
            HasKey(o => o.ClienteId);
        }
    }
}