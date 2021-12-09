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
    public class ProjectConfiguration : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.ToTable("Projects")
                .HasKey(p => new { p.projectid });
            //builder
            //    .HasOne<ProjectManages>(p => p.Manages)
            //    .WithOne(p => p.Project);
            //builder
            //   .HasMany<Assigns>(a => a.Assigns)
            //   .WithOne(a => a.Projects)
            //   .HasForeignKey(a => a.projectid);
            builder
               .HasMany<Affairs>(a => a.Affairs)
               .WithOne(a => a.Project)
               .HasForeignKey(a => a.projectid);
            //builder
            //   .HasOne<Projectcost>(p => p.Projectcosts)
            //   .WithOne(p => p.Projects);
            //builder
            //   .HasMany<Groups>(u => u.group)
            //   .WithOne(ug => ug.project)
            //   .HasForeignKey(u => u.projectid);
        }
    }
}