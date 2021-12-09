using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class addareabackup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 1,
                column: "displayname",
                value: "Employee");

            migrationBuilder.InsertData(
                table: "Authapplication",
                columns: new[] { "authapplicationid", "displayname", "name" },
                values: new object[] { 6, "Backup Database", "Backup" });

            migrationBuilder.UpdateData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 1,
                column: "display",
                value: "List Employee");

            migrationBuilder.InsertData(
                table: "Authcontroller",
                columns: new[] { "authcontrollerid", "authapplicationid", "display", "iconclass", "name" },
                values: new object[] { 6, 6, "Backup Database", "fas fa-calculator", "Backup" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 1,
                column: "displayname",
                value: "Người Dùng");

            migrationBuilder.UpdateData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 1,
                column: "display",
                value: "Danh Sách Người Dùng");
        }
    }
}
