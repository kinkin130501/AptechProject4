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
    public class GroupConfiguration : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.ToTable("Groups")
                .HasKey(g => new { g.groupid });
            //builder
            //    .HasOne<User>(ur => ur.user)
            //    .WithMany(u => u.group)
            //    .HasForeignKey(ur => ur.userid);

            //builder
            //    .HasOne<Projects>(ur => ur.project)
            //    .WithMany(u => u.group)
            //    .HasForeignKey(ur => ur.projectid);
        }
    }
}
