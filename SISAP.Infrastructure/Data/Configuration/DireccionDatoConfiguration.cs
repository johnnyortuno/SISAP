using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SISAP.Core.Entities;

namespace SISAP.Infrastructure.Data.Configuration
{
    class DireccionDatoConfiguration : EntityTypeConfiguration<DireccionDato>
    {
        public DireccionDatoConfiguration()
        {
            ToTable("DireccionDato", "dbo");
            HasKey(o => o.DireccionDatoId);

        }
    }
}
