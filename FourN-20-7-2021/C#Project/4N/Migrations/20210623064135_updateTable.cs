using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authapplication",
                columns: new[] { "authapplicationid", "displayname", "name" },
                values: new object[,]
                {
                    { 2, "Project Cost", "KOPC" },
                    { 3, "Group", "KOPC" },
                    { 4, "Over Time", "KOPC" },
                    { 5, "KPI", "KOPC" }
                });

            migrationBuilder.UpdateData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 1,
                column: "iconclass",
                value: "fas fa-users");

            migrationBuilder.InsertData(
                table: "Authcontroller",
                columns: new[] { "authcontrollerid", "authapplicationid", "display", "iconclass", "name" },
                values: new object[,]
                {
                    { 2, 2, "Cost", "fas fa-dollar-sign", "Projectcost" },
                    { 3, 3, "All Group", "fas fa-user-friends", "Group" },
                    { 4, 4, "Overtime request", "fas fa-business-time", "Overtime" },
                    { 5, 5, "Member's KPI", "fas fa-calculator", "KPI" }
                });

            migrationBuilder.InsertData(
                table: "Authuser",
                columns: new[] { "authappliactionid", "userid" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authuser",
                keyColumns: new[] { "authappliactionid", "userid" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Authuser",
                keyColumns: new[] { "authappliactionid", "userid" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Authuser",
                keyColumns: new[] { "authappliactionid", "userid" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Authuser",
                keyColumns: new[] { "authappliactionid", "userid" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authapplication",
                keyColumn: "authapplicationid",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Authcontroller",
                keyColumn: "authcontrollerid",
                keyValue: 1,
                column: "iconclass",
                value: "fas fa - users");
        }
    }
}
