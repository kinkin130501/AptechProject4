using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class addtableforauthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authapplication",
                columns: table => new
                {
                    authapplicationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    displayname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authapplication", x => x.authapplicationid);
                });

            migrationBuilder.CreateTable(
                name: "Authcontroller",
                columns: table => new
                {
                    authcontrollerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iconclass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authapplicationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authcontroller", x => x.authcontrollerid);
                    table.ForeignKey(
                        name: "FK_Authcontroller_Authapplication_authapplicationid",
                        column: x => x.authapplicationid,
                        principalTable: "Authapplication",
                        principalColumn: "authapplicationid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authuser",
                columns: table => new
                {
                    authappliactionid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authuser", x => new { x.authappliactionid, x.userid });
                    table.ForeignKey(
                        name: "FK_Authuser_Authapplication_authappliactionid",
                        column: x => x.authappliactionid,
                        principalTable: "Authapplication",
                        principalColumn: "authapplicationid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authuser_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authuserrole",
                columns: table => new
                {
                    authapplicationid = table.Column<int>(type: "int", nullable: false),
                    userroleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authuserrole", x => new { x.authapplicationid, x.userroleid });
                    table.ForeignKey(
                        name: "FK_Authuserrole_Authapplication_authapplicationid",
                        column: x => x.authapplicationid,
                        principalTable: "Authapplication",
                        principalColumn: "authapplicationid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authuserrole_Userrole_userroleid",
                        column: x => x.userroleid,
                        principalTable: "Userrole",
                        principalColumn: "userroleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authcontroller_authapplicationid",
                table: "Authcontroller",
                column: "authapplicationid");

            migrationBuilder.CreateIndex(
                name: "IX_Authuser_userid",
                table: "Authuser",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Authuserrole_userroleid",
                table: "Authuserrole",
                column: "userroleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authcontroller");

            migrationBuilder.DropTable(
                name: "Authuser");

            migrationBuilder.DropTable(
                name: "Authuserrole");

            migrationBuilder.DropTable(
                name: "Authapplication");

            migrationBuilder.DropColumn(
                name: "password",
                table: "User");
        }
    }
}
