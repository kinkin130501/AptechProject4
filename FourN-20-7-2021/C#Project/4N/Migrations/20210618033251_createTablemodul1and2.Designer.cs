﻿// <auto-generated />
using System;
using FourN.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FourN.Data.Migrations
{
    [DbContext(typeof(FourNDbContext))]
    [Migration("20210618033251_createTablemodul1and2")]
    partial class createTablemodul1and2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FourN.Data.Models.Affairs", b =>
                {
                    b.Property<int>("affairid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("affairname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("affairtag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("projectid")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeofaffair")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("affairid");

                    b.HasIndex("projectid");

                    b.ToTable("Affairs");
                });


            modelBuilder.Entity("FourN.Data.Models.Authapplication", b =>
                {
                    b.Property<int>("authapplicationid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("displayname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("authapplicationid");

                    b.ToTable("Authapplication");

                    b.HasData(
                        new
                        {
                            authapplicationid = 1,
                            displayname = "Người Dùng",
                            name = "User"
                        });
                });

            modelBuilder.Entity("FourN.Data.Models.Authcontroller", b =>
                {
                    b.Property<int>("authcontrollerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("authapplicationid")
                        .HasColumnType("int");

                    b.Property<string>("display")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iconclass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("authcontrollerid");

                    b.HasIndex("authapplicationid");

                    b.ToTable("Authcontroller");

                    b.HasData(
                        new
                        {
                            authcontrollerid = 1,
                            authapplicationid = 1,
                            display = "Danh Sách Người Dùng",
                            iconclass = "fas fa - users",
                            name = "User"
                        });
                });

            modelBuilder.Entity("FourN.Data.Models.Authuser", b =>
                {
                    b.Property<int>("authappliactionid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("authappliactionid", "userid");

                    b.HasIndex("userid");

                    b.ToTable("Authuser");

                    b.HasData(
                        new
                        {
                            authappliactionid = 1,
                            userid = 1
                        });
                });

            modelBuilder.Entity("FourN.Data.Models.Authuserrole", b =>
                {
                    b.Property<int>("authapplicationid")
                        .HasColumnType("int");

                    b.Property<int>("userroleid")
                        .HasColumnType("int");

                    b.HasKey("authapplicationid", "userroleid");

                    b.HasIndex("userroleid");

                    b.ToTable("Authuserrole");
                });


            modelBuilder.Entity("FourN.Data.Models.Documents", b =>
                {
                    b.Property<int>("docid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("authorname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("authorrole")
                        .HasColumnType("int");

                    b.Property<string>("file")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("docid");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("FourN.Data.Models.Groupuser", b =>
                {
                    b.Property<int>("userid")
                        .HasColumnType("int");


                    b.ToTable("Groupuser");
                });

            modelBuilder.Entity("FourN.Data.Models.KPIs", b =>
                {
                    b.Property<int>("kpiid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("membername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectdone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.Property<string>("worktime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kpiid");

                    b.HasIndex("userid");

                    b.ToTable("KPIs");
                });

            modelBuilder.Entity("FourN.Data.Models.Otime", b =>
                {
                    b.Property<int>("otid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");


                    b.Property<string>("reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("timedelay")
                        .HasColumnType("datetime2");

                    b.HasKey("otid");


                    b.ToTable("Otime");
                });


            modelBuilder.Entity("FourN.Data.Models.Projects", b =>
                {
                    b.Property<int>("projectid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("affairid")
                        .HasColumnType("int");

                    b.Property<int>("assignid")
                        .HasColumnType("int");

                    b.Property<string>("duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("projectid");


                    b.ToTable("Projects");
                });

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

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            userid = 1,
                            email = "admin@gmail.com",
                            isemployee = false,
                            islead = false,
                            password = "123456789",
                            phone = "0123456789",
                            username = "Admin"
                        });
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

            modelBuilder.Entity("FourN.Data.Models.Affairs", b =>
                {
                    b.HasOne("FourN.Data.Models.Projects", "Project")
                        .WithMany("Affairs")
                        .HasForeignKey("projectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("FourN.Data.Models.Authcontroller", b =>
                {
                    b.HasOne("FourN.Data.Models.Authapplication", "authapplication")
                        .WithMany("authcontrollers")
                        .HasForeignKey("authapplicationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("authapplication");
                });

            modelBuilder.Entity("FourN.Data.Models.Authuser", b =>
                {
                    b.HasOne("FourN.Data.Models.Authapplication", "authapplication")
                        .WithMany("authuser")
                        .HasForeignKey("authappliactionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourN.Data.Models.User", "user")
                        .WithMany("authusers")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("authapplication");

                    b.Navigation("user");
                });

            modelBuilder.Entity("FourN.Data.Models.Authuserrole", b =>
                {
                    b.HasOne("FourN.Data.Models.Authapplication", "authapplication")
                        .WithMany("authuserroles")
                        .HasForeignKey("authapplicationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourN.Data.Models.Userrole", "userrole")
                        .WithMany("authuserroles")
                        .HasForeignKey("userroleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("authapplication");

                    b.Navigation("userrole");
                });



            modelBuilder.Entity("FourN.Data.Models.KPIs", b =>
                {
                    b.HasOne("FourN.Data.Models.User", "user")
                        .WithMany("kpi")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
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


            modelBuilder.Entity("FourN.Data.Models.Authapplication", b =>
                {
                    b.Navigation("authcontrollers");

                    b.Navigation("authuser");

                    b.Navigation("authuserroles");
                });



            modelBuilder.Entity("FourN.Data.Models.Projects", b =>
                {
                    b.Navigation("Affairs");

                });

            modelBuilder.Entity("FourN.Data.Models.User", b =>
                {
                    b.Navigation("authusers");


                    b.Navigation("kpi");

                    b.Navigation("useruserroles");
                });

            modelBuilder.Entity("FourN.Data.Models.Userrole", b =>
                {
                    b.Navigation("authuserroles");

                    b.Navigation("useruserroles");
                });
#pragma warning restore 612, 618
        }
    }
}