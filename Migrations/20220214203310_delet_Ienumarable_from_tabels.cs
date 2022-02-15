using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paramdic.Migrations
{
    public partial class delet_Ienumarable_from_tabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aidrequested");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aidrequested",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Daterequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalImagePath = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PersonalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialStatusId = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidrequested", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aidrequested_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aidrequested_City_StatusID",
                        column: x => x.StatusID,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aidrequested_socialStatuses_SocialStatusId",
                        column: x => x.SocialStatusId,
                        principalTable: "socialStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aidrequested_CategoryId",
                table: "Aidrequested",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Aidrequested_SocialStatusId",
                table: "Aidrequested",
                column: "SocialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Aidrequested_StatusID",
                table: "Aidrequested",
                column: "StatusID");
        }
    }
}
