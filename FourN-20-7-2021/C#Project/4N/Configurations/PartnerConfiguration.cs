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
    public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.ToTable("Partner")
                .HasKey(dp => new { dp.partnerid });
            builder
                .HasOne<Departmentpartner>(ur => ur.departmentpartner)
                .WithMany(u => u.partners)
                .HasForeignKey(ur => ur.departmentpartnerid);

        }
    }
}
