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
    public class AuthuserroleConfiguration : IEntityTypeConfiguration<Authuserrole>
    {
        public void Configure(EntityTypeBuilder<Authuserrole> builder)
        {
            builder.ToTable("Authuserrole")
                .HasKey(ath => new { ath.authapplicationid, ath.userroleid });

            builder
                .HasOne<Userrole>(ath => ath.userrole)
                .WithMany(u => u.authuserroles)
                .HasForeignKey(ur => ur.userroleid);

            builder
                .HasOne<Authapplication>(ur => ur.authapplication)
                .WithMany(u => u.authuserroles)
                .HasForeignKey(ur => ur.authapplicationid);
        }
    }
}
