﻿// <auto-generated />
using FourN.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FourN.Data.Migrations
{
    [DbContext(typeof(FourNDbContext))]
    [Migration("20210504095811_update table user")]
    partial class updatetableuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FourN.Data.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isemployee")
                        .HasColumnType("bit");

                    b.Property<bool>("islead")
                        .HasColumnType("bit");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FourN.Data.Models.Userrole", b =>
                {
                    b.Property<int>("userroleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("displayname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isprivate")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userroleid");

                    b.ToTable("Userrole");
                });

            modelBuilder.Entity("FourN.Data.Models.Useruserrole", b =>
                {
                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.Property<int>("userroleid")
                        .HasColumnType("int");

                    b.HasKey("userid", "userroleid");

                    b.HasIndex("userroleid");

                    b.ToTable("Useruserrole");
                });

            modelBuilder.Entity("FourN.Data.Models.Useruserrole", b =>
                {
                    b.HasOne("FourN.Data.Models.User", "user")
                        .WithMany("useruserroles")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourN.Data.Models.Userrole", "userrole")
                        .WithMany("useruserroles")
                        .HasForeignKey("userroleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");

                    b.Navigation("userrole");
                });

            modelBuilder.Entity("FourN.Data.Models.User", b =>
                {
                    b.Navigation("useruserroles");
                });

            modelBuilder.Entity("FourN.Data.Models.Userrole", b =>
                {
                    b.Navigation("useruserroles");
                });
#pragma warning restore 612, 618
        }
    }
}
