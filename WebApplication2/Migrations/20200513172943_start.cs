using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    idAccess = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameAccess = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.idAccess);
                });

            migrationBuilder.CreateTable(
                name: "Decor",
                columns: table => new
                {
                    idDecor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameDecor = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    surnameDecor = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decor", x => x.idDecor);
                });

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    idLeader = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameLeader = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    surnameLeader = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leader", x => x.idLeader);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    idPhoto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    namePhoto = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    surnamePhoto = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.idPhoto);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    idPlace = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    namePlace = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.idPlace);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    idRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameRole = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "TypeEvent",
                columns: table => new
                {
                    idType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameType = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEvent", x => x.idType);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameUser = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    surname = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    loginUser = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    passwordUser = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    roleUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                    table.ForeignKey(
                        name: "FK__User__roleUser__3B75D760",
                        column: x => x.roleUser,
                        principalTable: "RoleUser",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    idEvent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameEvent = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    typeEvent = table.Column<int>(nullable: false),
                    amount = table.Column<int>(nullable: false),
                    dateEvent = table.Column<DateTime>(type: "datetime", nullable: false),
                    organizer = table.Column<int>(nullable: false),
                    city = table.Column<string>(unicode: false, maxLength: 280, nullable: false),
                    sreet = table.Column<string>(unicode: false, maxLength: 280, nullable: false),
                    house = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    cost = table.Column<decimal>(type: "smallmoney", nullable: true),
                    access = table.Column<int>(nullable: false),
                    leader = table.Column<int>(nullable: true),
                    place = table.Column<int>(nullable: false),
                    decor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.idEvent);
                    table.ForeignKey(
                        name: "FK__Event__access__68487DD7",
                        column: x => x.access,
                        principalTable: "Access",
                        principalColumn: "idAccess",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Event__decor__6B24EA82",
                        column: x => x.decor,
                        principalTable: "Decor",
                        principalColumn: "idDecor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Event__leader__693CA210",
                        column: x => x.leader,
                        principalTable: "Leader",
                        principalColumn: "idLeader",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Event__organizer__6754599E",
                        column: x => x.organizer,
                        principalTable: "User",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Event__place__6A30C649",
                        column: x => x.place,
                        principalTable: "Place",
                        principalColumn: "idPlace",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Event__typeEvent__66603565",
                        column: x => x.typeEvent,
                        principalTable: "TypeEvent",
                        principalColumn: "idType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventUsers",
                columns: table => new
                {
                    idEU = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idUser = table.Column<int>(nullable: false),
                    idEvent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUsers", x => x.idEU);
                    table.ForeignKey(
                        name: "FK__EventUser__idEve__6EF57B66",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EventUser__idUse__6E01572D",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_access",
                table: "Event",
                column: "access");

            migrationBuilder.CreateIndex(
                name: "IX_Event_decor",
                table: "Event",
                column: "decor");

            migrationBuilder.CreateIndex(
                name: "IX_Event_leader",
                table: "Event",
                column: "leader");

            migrationBuilder.CreateIndex(
                name: "IX_Event_organizer",
                table: "Event",
                column: "organizer");

            migrationBuilder.CreateIndex(
                name: "IX_Event_place",
                table: "Event",
                column: "place");

            migrationBuilder.CreateIndex(
                name: "IX_Event_typeEvent",
                table: "Event",
                column: "typeEvent");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_idEvent",
                table: "EventUsers",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_idUser",
                table: "EventUsers",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleUser",
                table: "User",
                column: "roleUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUsers");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Decor");

            migrationBuilder.DropTable(
                name: "Leader");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "TypeEvent");

            migrationBuilder.DropTable(
                name: "RoleUser");
        }
    }
}
