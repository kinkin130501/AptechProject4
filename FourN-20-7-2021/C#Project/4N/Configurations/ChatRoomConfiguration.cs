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
    public class ChatRoomConfiguration : IEntityTypeConfiguration<Chatroom>
    {
        public void Configure(EntityTypeBuilder<Chatroom> builder)
        {
            builder.ToTable("Chatroom").HasKey(z => new { z.chatroomid });
        }
    }
}
