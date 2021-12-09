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
    public class DocumentConfiguration : IEntityTypeConfiguration<Documents>
    {
        public void Configure(EntityTypeBuilder<Documents> builder)
        {
            builder.ToTable("Documents")
                .HasKey(dc => new { dc.docid });
            //builder
            //    .HasMany<Assigns>(a=>a.Assigns)
            //    .WithOne(d => d.Document)
            //    .HasForeignKey(d => d.docid);
        }
    }
}