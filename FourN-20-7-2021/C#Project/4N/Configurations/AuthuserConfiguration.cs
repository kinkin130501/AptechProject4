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
    public class AuthuserConfiguration : IEntityTypeConfiguration<Authuser>
    {
        public void Configure(EntityTypeBuilder<Authuser> builder)
        {
            builder.ToTable("Authuser")
                 .HasKey(ath => new { ath.authappliactionid, ath.userid });

            builder
                .HasOne<User>(ath => ath.user)
                .WithMany(u => u.authusers)
                .HasForeignKey(ur => ur.userid);

            builder
                .HasOne<Authapplication>(ur => ur.authapplication)
                .WithMany(u => u.authuser)
                .HasForeignKey(ur => ur.authappliactionid);
            builder.HasData(new Authuser
            {
                authappliactionid = 1,
                userid = 1,
            });
            builder.HasData(new Authuser
            {
                authappliactionid = 2,
                userid = 1,
            });
            builder.HasData(new Authuser
            {
                authappliactionid = 3,
                userid = 1,
            });
            builder.HasData(new Authuser
            {
                authappliactionid = 4,
                userid = 1,
            });
            builder.HasData(new Authuser
            {
                authappliactionid = 5,
                userid = 1,
            });
            builder.HasData(new Authuser
            {
                authappliactionid = 6,
                userid = 1,
            });
        }
    }
}
