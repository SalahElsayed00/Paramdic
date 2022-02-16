using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paramdic.Migrations
{
    public partial class rename_aidrequsetd_to_cases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aidrequesteds");

            migrationBuilder.CreateTable(
                name: "cases",
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
                    table.PrimaryKey("PK_cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cases_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cases_socialStatuses_SocialStatusId",
                        column: x => x.SocialStatusId,
                        principalTable: "socialStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cases_statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cases_CategoryId",
                table: "cases",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_cases_SocialStatusId",
                table: "cases",
                column: "SocialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_cases_StatusID",
                table: "cases",
                column: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cases");

            migrationBuilder.CreateTable(
                name: "aidrequesteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Daterequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalImagePath = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PersonalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialStatusId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_aidrequesteds_socialStatuses_SocialStatusId",
                        column: x => x.SocialStatusId,
                        principalTable: "socialStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aidrequesteds_statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
        }
    }
}
