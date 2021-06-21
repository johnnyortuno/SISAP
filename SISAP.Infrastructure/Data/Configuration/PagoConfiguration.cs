﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;


namespace SISAP.Infrastructure.Data.Configuration
{
    class PagoConfiguration : EntityTypeConfiguration<Pago>
    {
        public PagoConfiguration()
        {
            ToTable("Pago", "dbo");
            HasKey(o => o.PagoId);
        }
    }
}
