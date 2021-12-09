using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourN.Data.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    docid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorrole = table.Column<int>(type: "int", nullable: false),
                    authorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    files = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.docid);
                });

            migrationBuilder.CreateTable(
                name: "KPIs",
                columns: table => new
                {
                    kpiid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    worktime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectdone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIs", x => x.kpiid);
                    table.ForeignKey(
                        name: "FK_KPIs_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projectcost",
                columns: table => new
                {
                    projectcostid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estimatedcosts = table.Column<double>(type: "float", nullable: true),
                    costsincurred = table.Column<double>(type: "float", nullable: true),
                    actualcosts = table.Column<double>(type: "float", nullable: true),
                    currencyunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectcost", x => x.projectcostid);
                });
            // module 4
            migrationBuilder.CreateTable(
                name: "Zoom",
                columns: table => new
                {
                    zoomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zoomtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zoomcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zoomstarturl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zoomhost = table.Column<int>(type: "int", nullable: true),
                    zoomjoinurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zoompass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zoomteam = table.Column<int>(type: "int", nullable: true),
                    zoommember = table.Column<int>(type: "int", nullable: true),
                    zoomcreateat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zoomupdateat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoom", x => x.zoomid);
                });

            migrationBuilder.CreateTable(
                name: "Privatemessage",
                columns: table => new
                {
                    messageid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messagetitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    messagesenderid = table.Column<int>(type: "int", nullable: true),
                    messagereceiveid = table.Column<int>(type: "int", nullable: true),
                    messagecontent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    messagecreateat= table.Column<string>(type: "nvarchar(max)", nullable: true),
                    messageupdateat= table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.messageid);
                });
            migrationBuilder.CreateTable(
                name: "Chatroom",
                columns: table => new
                {
                    chatroomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chatuserid = table.Column<int>(type: "int", nullable: true),
                    chatusercontent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chatusergroup = table.Column<int>(type: "int", nullable: true),
                    chatusercreateat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chatuserupdateat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.chatroomid);
                });
            //end module 4
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectmanageid = table.Column<int>(type: "int", nullable: true),
                    projectcostid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectid);
                    table.ForeignKey(
                        name: "FK_Projects_Projectcost_projectcostid",
                        column: x => x.projectcostid,
                        principalTable: "Projectcost",
                        principalColumn: "projectcostid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Affairs",
                columns: table => new
                {
                    affairid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    affairname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    affairtag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    typeofaffair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affairs", x => x.affairid);
                    table.ForeignKey(
                        name: "FK_Affairs_Projects_projectid",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "projectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assigns",
                columns: table => new
                {
                    assignid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    affairid = table.Column<int>(type: "int", nullable: false),
                    typeofaffair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    begintime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    docid = table.Column<int>(type: "int", nullable: true),
                    leaderid = table.Column<int>(type: "int", nullable: true),
                    memberid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigns", x => x.assignid);
                    table.ForeignKey(
                        name: "FK_Assigns_Documents_docid",
                        column: x => x.docid,
                        principalTable: "Documents",
                        principalColumn: "docid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assigns_Projects_projectid",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "projectid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    groupid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: false),
                    projectid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.groupid);
                    table.ForeignKey(
                        name: "FK_Groups_Projects_projectid",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "projectid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projectmanages",
                columns: table => new
                {
                    projectmanageid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    members = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectmanages", x => x.projectmanageid);
                    table.ForeignKey(
                        name: "FK_Projectmanages_Projects_projectid",
                        column: x => x.projectid,
                        principalTable: "Projects",
                        principalColumn: "projectid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Changestatusprojects",
                columns: table => new
                {
                    changeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectid = table.Column<int>(type: "int", nullable: false),
                    leaderid = table.Column<int>(type: "int", nullable: false),
                    affairid = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changestatusprojects", x => x.changeid);
                    table.ForeignKey(
                        name: "FK_Changestatusprojects_Affairs_affairid",
                        column: x => x.affairid,
                        principalTable: "Affairs",
                        principalColumn: "affairid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Otime",
                columns: table => new
                {
                    otid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timedelay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    projectmanageid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otime", x => x.otid);
                    table.ForeignKey(
                        name: "FK_Otime_Projectmanages_projectmanageid",
                        column: x => x.projectmanageid,
                        principalTable: "Projectmanages",
                        principalColumn: "projectmanageid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affairs_projectid",
                table: "Affairs",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_docid",
                table: "Assigns",
                column: "docid");

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_projectid",
                table: "Assigns",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Changestatusprojects_affairid",
                table: "Changestatusprojects",
                column: "affairid");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_projectid",
                table: "Groups",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_userid",
                table: "Groups",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_KPIs_userid",
                table: "KPIs",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Otime_projectmanageid",
                table: "Otime",
                column: "projectmanageid");

            migrationBuilder.CreateIndex(
                name: "IX_Projectmanages_projectid",
                table: "Projectmanages",
                column: "projectid",
                unique: true,
                filter: "[projectid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_projectcostid",
                table: "Projects",
                column: "projectcostid",
                unique: true,
                filter: "[projectcostid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assigns");

            migrationBuilder.DropTable(
                name: "Changestatusprojects");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "KPIs");

            migrationBuilder.DropTable(
                name: "Otime");

            migrationBuilder.DropTable(
                name: "Zoom");
            migrationBuilder.DropTable(
                name: "Privatemessage");
            migrationBuilder.DropTable(
                name: "Chatroom");
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Affairs");

            migrationBuilder.DropTable(
                name: "Projectmanages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Projectcost");
        }
    }
}
