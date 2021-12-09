using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class changecolumngroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "Groupuser");

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "Groups");

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "Groupuser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
