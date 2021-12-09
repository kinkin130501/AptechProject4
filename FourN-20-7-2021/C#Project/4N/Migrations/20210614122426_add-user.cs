using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userid", "email", "isemployee", "islead", "password", "phone", "username" },
                values: new object[] { 1, "admin.com", false, false, "123456789", "0123456789", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userid",
                keyValue: 1);
        }
    }
}
