using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISAP.Infrastructure.Data.Configuration
{
    class CiclosConfiguration : EntityTypeConfiguration<Ciclos>
    {
        public CiclosConfiguration()
        {
            ToTable("Ciclos", "dbo");
            HasKey(o => o.CiclosId);
            Property(o => o.CiclosId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

        }
    }
}
