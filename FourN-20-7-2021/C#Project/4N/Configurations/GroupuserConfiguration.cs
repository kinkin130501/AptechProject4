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
    public class GroupuserConfiguration: IEntityTypeConfiguration<Groupuser>
    {
        public void Configure(EntityTypeBuilder<Groupuser> builder)
        {
            builder.ToTable("Groupuser")
                .HasKey(ur => new { ur.userid, ur.groupid });

            builder
                .HasOne<User>(ur => ur.user)
                .WithMany(u => u.groupusers)
                .HasForeignKey(ur => ur.userid);

            builder
                .HasOne<Groups>(ur => ur.group)
                .WithMany(u => u.groupusers)
                .HasForeignKey(ur => ur.groupid);
        }
    }
}
