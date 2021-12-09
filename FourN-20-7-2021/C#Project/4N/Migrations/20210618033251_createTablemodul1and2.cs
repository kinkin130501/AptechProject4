using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class createTablemodul1and2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    docid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorrole = table.Column<int>(type: "int", nullable: true),
                    authorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    files = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.docid);
                });

            migrationBuilder.CreateTable(
                name: "KPIs",
                columns: table => new
                {
                    kpiid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    worktime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectdone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIs", x => x.kpiid);
                    table.ForeignKey(
                        name: "FK_KPIs_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endplan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startactual = table.Column<DateTime>(type: "datetime2", nullable: true),
                    startplan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endactual = table.Column<DateTime>(type: "datetime2", nullable: true),
                    leaderid = table.Column<int>(type: "int", nullable: true),
                    docid = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "varchar(max)", nullable: true),
                    status = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectid);
                });

            migrationBuilder.CreateTable(
                name: "Affairs",
                columns: table => new
                {
                    affairid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    affairname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    affairtag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    starttimeplan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endtimeplan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    starttimeactual = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endtimeactual = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    notemember = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noteleader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affairs", x => x.affairid);
                    table.ForeignKey(
                        name: "FK_Affairs_Projects_projectid",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "projectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groupuser",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupuser", x => new { x.userid});
                    table.ForeignKey(
                        name: "FK_Groupuser_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Otime",
                columns: table => new
                {
                    otid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timedelay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otime", x => x.otid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affairs_projectid",
                table: "Affairs",
                column: "projectid");


            migrationBuilder.CreateIndex(
                name: "IX_KPIs_userid",
                table: "KPIs",
                column: "userid");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Groupuser");

            migrationBuilder.DropTable(
                name: "KPIs");

            migrationBuilder.DropTable(
                name: "Otime");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Affairs");


            migrationBuilder.DropTable(
                name: "Projects");

        }
    }
}
