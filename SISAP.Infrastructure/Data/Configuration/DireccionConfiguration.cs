using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SISAP.Core.Entities;

namespace SISAP.Infrastructure.Data.Configuration
{
    class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            ToTable("Direccion", "dbo");
            HasKey(o => o.DireccionId);
        }
    }
}
