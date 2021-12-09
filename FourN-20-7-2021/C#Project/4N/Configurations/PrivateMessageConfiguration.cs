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
    class PrivateMessageConfiguration : IEntityTypeConfiguration<Privatemessage>
    {
        public void Configure(EntityTypeBuilder<Privatemessage> builder)
        {
            builder.ToTable("PrivateMessage").HasKey(m => new { m.messageid });
        }
    }
}
