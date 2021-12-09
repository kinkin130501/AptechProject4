using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class addModule4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatroom",
                columns: table => new
                {
                    chatroomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chatuserid = table.Column<int>(type: "int", nullable: false),
                    chatusercontent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chatusergroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chatusercreateat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chatuserupdateat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatroom", x => x.chatroomid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chatroom");
        }
    }
}
