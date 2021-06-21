using SISAP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Data.Configuration
{
	class FacturacionConfiguration : EntityTypeConfiguration<Facturacion>
    {
        public FacturacionConfiguration()
        {
            ToTable("Facturacion", "dbo");
            HasKey(o => o.FacturacionId);
        }
    }
}