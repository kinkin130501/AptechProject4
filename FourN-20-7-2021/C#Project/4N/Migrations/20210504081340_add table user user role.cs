using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class addtableuseruserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "Userrole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userrole",
                table: "Userrole",
                column: "userroleid");

            migrationBuilder.CreateTable(
                name: "Useruserrole",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false),
                    userroleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Useruserrole", x => new { x.userid, x.userroleid });
                    table.ForeignKey(
                        name: "FK_Useruserrole_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Useruserrole_Userrole_userroleid",
                        column: x => x.userroleid,
                        principalTable: "Userrole",
                        principalColumn: "userroleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Useruserrole_userroleid",
                table: "Useruserrole",
                column: "userroleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Useruserrole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userrole",
                table: "Userrole");

            migrationBuilder.RenameTable(
                name: "Userrole",
                newName: "UserRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "userroleid");
        }
    }
}
