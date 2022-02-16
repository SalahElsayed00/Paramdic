using Microsoft.EntityFrameworkCore.Migrations;

namespace Paramdic.Migrations
{
    public partial class altertableAidrequisted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aidrequesteds_cities_StatusID",
                table: "aidrequesteds");

            migrationBuilder.AddForeignKey(
                name: "FK_aidrequesteds_statuses_StatusID",
                table: "aidrequesteds",
                column: "StatusID",
                principalTable: "statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aidrequesteds_statuses_StatusID",
                table: "aidrequesteds");

            migrationBuilder.AddForeignKey(
                name: "FK_aidrequesteds_cities_StatusID",
                table: "aidrequesteds",
                column: "StatusID",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
