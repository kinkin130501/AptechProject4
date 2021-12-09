using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Projects_Projectsprojectid",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_Projectsprojectid",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Projectsprojectid",
                table: "Groups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Projectsprojectid",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Projectsprojectid",
                table: "Groups",
                column: "Projectsprojectid");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Projects_Projectsprojectid",
                table: "Groups",
                column: "Projectsprojectid",
                principalTable: "Projects",
                principalColumn: "projectid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
