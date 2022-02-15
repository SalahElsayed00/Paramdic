using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paramdic.Migrations
{
    public partial class add_aid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_City_regions_RegionId",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "cities");

            migrationBuilder.RenameIndex(
                name: "IX_City_RegionId",
                table: "cities",
                newName: "IX_cities_RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "aidrequesteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Daterequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalImagePath = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PersonalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SocialStatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aidrequesteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aidrequesteds_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aidrequesteds_cities_StatusID",
                        column: x => x.StatusID,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aidrequesteds_socialStatuses_SocialStatusId",
                        column: x => x.SocialStatusId,
                        principalTable: "socialStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aidrequesteds_CategoryId",
                table: "aidrequesteds",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_aidrequesteds_SocialStatusId",
                table: "aidrequesteds",
                column: "SocialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_aidrequesteds_StatusID",
                table: "aidrequesteds",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_regions_RegionId",
                table: "cities",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_cities_regions_RegionId",
                table: "cities");

            migrationBuilder.DropTable(
                name: "aidrequesteds");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_cities_RegionId",
                table: "City",
                newName: "IX_City_RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_regions_RegionId",
                table: "City",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
