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
    public class AuthapplicationConfiguration: IEntityTypeConfiguration<Authapplication>
    {
        public void Configure(EntityTypeBuilder<Authapplication> builder)
        {
            // builder.ToTable("Authapplication")
            //.HasMany<Authcontroller>(u => u.authcontrollers)
            //.WithOne(u => u.authapplication)
            //.HasForeignKey(u => u.authapplicationid);
            builder.HasData(new Authapplication { 
            authapplicationid = 1,
            name = "User",
            displayname = "Employee"
            });
            builder.HasData(new Authapplication
            {
                authapplicationid = 2,
                name = "KOPC",
                displayname = "Project Cost"
            });
            builder.HasData(new Authapplication
            {
                authapplicationid = 3,
                name = "KOPC",
                displayname = "Group"
            });
            builder.HasData(new Authapplication
            {
                authapplicationid = 4,
                name = "KOPC",
                displayname = "Over Time"
            });
            builder.HasData(new Authapplication
            {
                authapplicationid = 5,
                name = "KOPC",
                displayname = "KPI"
            });
            builder.HasData(new Authapplication
            {
                authapplicationid = 6,
                name = "Backup",
                displayname = "Backup Database"
            });
        }
    }
}
