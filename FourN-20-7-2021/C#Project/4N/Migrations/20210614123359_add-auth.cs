using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class addauth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authapplication",
                columns: new[] { "authapplicationid", "displayname", "name" },
                values: new object[] { 1, "Người Dùng", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userid",
                keyValue: 1,
                column: "email",
                value: "admin@gmail.com");

            migrationBuilder.InsertData(
                table: "Authcontroller",
                columns: new[] { "authcontrollerid", "authapplicationid", "display", "iconclass", "name" },
                values: new object[] { 1, 1, "Danh Sách Người Dùng", "fas fa - users", "User" });

            migrationBuilder.InsertData(
                table: "Authuser",
                columns: new[] { "authappliactionid", "userid" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authuser",
                keyColumns: new[] { "authappliactionid", "userid" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userid",
                keyValue: 1,
                column: "email",
                value: "admin.com");
        }
    }
}
