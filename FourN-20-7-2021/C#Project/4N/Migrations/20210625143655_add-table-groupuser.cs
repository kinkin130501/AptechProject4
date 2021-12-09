using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class addtablegroupuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Projects_projectid",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_User_userid",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_projectid",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "projectid",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Projectsprojectid",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groupuser",
                columns: table => new
                {
                    groupid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    isleader = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupuser", x => new { x.userid, x.groupid });
                    table.ForeignKey(
                        name: "FK_Groupuser_Groups_groupid",
                        column: x => x.groupid,
                        principalTable: "Groups",
                        principalColumn: "groupid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groupuser_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Projectsprojectid",
                table: "Groups",
                column: "Projectsprojectid");

            migrationBuilder.CreateIndex(
                name: "IX_Groupuser_groupid",
                table: "Groupuser",
                column: "groupid");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Projects_Projectsprojectid",
                table: "Groups",
                column: "Projectsprojectid",
                principalTable: "Projects",
                principalColumn: "projectid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_User_userid",
                table: "Groups",
                column: "userid",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Projects_Projectsprojectid",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_User_userid",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Groupuser");

            migrationBuilder.DropIndex(
                name: "IX_Groups_Projectsprojectid",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Projectsprojectid",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "projectid",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_projectid",
                table: "Groups",
                column: "projectid");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Projects_projectid",
                table: "Groups",
                column: "projectid",
                principalTable: "Projects",
                principalColumn: "projectid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_User_userid",
                table: "Groups",
                column: "userid",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
