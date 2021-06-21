﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISAP.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SISAP.Infrastructure.Data.Configuration
{
    public class TipoCategoriaConfiguration : EntityTypeConfiguration<TipoCategoria>
    {
        public TipoCategoriaConfiguration()
        {
            ToTable("TipoCategoria", "dbo");
            HasKey(o => o.TipoCategoriaId);
        }
    }
}
