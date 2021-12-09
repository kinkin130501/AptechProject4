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
    public class UserUserRoleConfiguration : IEntityTypeConfiguration<Useruserrole>
    {
        public void Configure(EntityTypeBuilder<Useruserrole> builder)
        {
            builder.ToTable("Useruserrole")
                .HasKey(ur => new {ur.userid, ur.userroleid});

            builder
                .HasOne<User>(ur => ur.user)
                .WithMany(u => u.useruserroles)
                .HasForeignKey(ur=>ur.userid);

            builder
                .HasOne<Userrole>(ur => ur.userrole)
                .WithMany(u => u.useruserroles)
                .HasForeignKey(ur=>ur.userroleid);
        }
    }
}
