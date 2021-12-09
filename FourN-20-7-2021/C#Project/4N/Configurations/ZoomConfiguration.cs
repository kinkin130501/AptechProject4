using FourN.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Configurations
{
    public class ZoomConfiguration : IEntityTypeConfiguration<Zoom>
    {
        public void Configure(EntityTypeBuilder<Zoom> builder)
        {
            builder.ToTable("Zoom").HasKey(z => new { z.zoomid });
        }

    }
}
