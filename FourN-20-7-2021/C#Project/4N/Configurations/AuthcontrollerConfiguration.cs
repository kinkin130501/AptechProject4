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
    public class AuthcontrollerConfiguration : IEntityTypeConfiguration<Authcontroller>
    {
        public void Configure(EntityTypeBuilder<Authcontroller> builder)
        {
            //builder.ToTable("Authcontroller")
            builder.HasData(new Authcontroller
            {
                authcontrollerid = 1,
                name = "User",
                display = "List Employee",
                iconclass = "fas fa-users",
                authapplicationid = 1
            });
            builder.HasData(new Authcontroller
            {
                authcontrollerid = 2,
                name = "Projectcost",
                display = "Cost",
                iconclass = "fas fa-dollar-sign",
                authapplicationid = 2
            });
            builder.HasData(new Authcontroller
            {
                authcontrollerid = 3,
                name = "Group",
                display = "All Group",
                iconclass = "fas fa-user-friends",
                authapplicationid = 3
            });
            builder.HasData(new Authcontroller
            {
                authcontrollerid = 4,
                name = "Overtime",
                display = "Overtime request",
                iconclass = "fas fa-business-time",
                authapplicationid = 4
            });
            builder.HasData(new Authcontroller
            {
                authcontrollerid = 5,
                name = "KPI",
                display = "Member's KPI",
                iconclass = "fas fa-calculator",
                authapplicationid = 5
            });
            builder.HasData(new Authcontroller
            {
                authcontrollerid = 6,
                name = "Backup",
                display = "Backup Database",
                iconclass = "fas fa-calculator",
                authapplicationid = 6
            });
        }
    }
}
