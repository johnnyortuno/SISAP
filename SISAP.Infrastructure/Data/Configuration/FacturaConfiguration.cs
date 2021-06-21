using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SISAP.Core.Entities;
namespace SISAP.Infrastructure.Data.Configuration
{
    public class FacturaConfiguration : EntityTypeConfiguration<Factura>
    {
        public FacturaConfiguration()
        {
            ToTable("Factura", "bdo");
            HasKey(o => o.FacturaId);
        }
    }
}
