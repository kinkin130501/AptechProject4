using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class addmisseduserauth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authuser",
                columns: new[] { "authappliactionid", "userid" },
                values: new object[] { 6, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authuser",
                keyColumns: new[] { "authappliactionid", "userid" },
                keyValues: new object[] { 6, 1 });
        }
    }
}
