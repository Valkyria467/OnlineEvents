using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class addMesageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Event__access__68487DD7",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropIndex(
                name: "IX_Event_access",
                table: "Event");

            migrationBuilder.AlterColumn<bool>(
                name: "access",
                table: "Event",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "InfoEvent",
                table: "Event",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "photo",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_photo",
                table: "Event",
                column: "photo");

            migrationBuilder.AddForeignKey(
                name: "FK__Event__photo__6FE99F9F",
                table: "Event",
                column: "photo",
                principalTable: "Photo",
                principalColumn: "idPhoto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Event__photo__6FE99F9F",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_photo",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "InfoEvent",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "photo",
                table: "Event");

            migrationBuilder.AlterColumn<int>(
                name: "access",
                table: "Event",
                nullable: false,
                oldClrType: typeof(bool));

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

            migrationBuilder.CreateIndex(
                name: "IX_Event_access",
                table: "Event",
                column: "access");

            migrationBuilder.AddForeignKey(
                name: "FK__Event__access__68487DD7",
                table: "Event",
                column: "access",
                principalTable: "Access",
                principalColumn: "idAccess",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
