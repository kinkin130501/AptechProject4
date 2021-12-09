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
    public class AffairConfiguration : IEntityTypeConfiguration<Affairs>
    {
        public void Configure(EntityTypeBuilder<Affairs> builder)
        {
            builder.ToTable("Affairs")
                .HasKey(aff => new { aff.affairid });
            builder
               .HasOne<Projects>(up => up.Project)
               .WithMany(a => a.Affairs)
               .HasForeignKey(ur => ur.projectid);
            //builder
            //    .HasMany<ChangeStatusProject>(c => c.Changes)
            //    .WithOne(a=>a.Affair)
            //    .HasForeignKey(u => u.affairid);
        }
    }
}
