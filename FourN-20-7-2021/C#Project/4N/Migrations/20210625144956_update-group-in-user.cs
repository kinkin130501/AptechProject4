using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class updategroupinuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_User_userid",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_userid",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Groups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_userid",
                table: "Groups",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_User_userid",
                table: "Groups",
                column: "userid",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
