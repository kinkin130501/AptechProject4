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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
                .HasMany<Useruserrole>(u => u.useruserroles)
                .WithOne(u => u.user)
                .HasForeignKey(u => u.userid);
            builder.HasData(new User
            {
                userid = 1,
                email = "admin@gmail.com",
                username = "Admin",
                password = "123456789",
                phone = "0123456789"
            });
        }
    }
}
