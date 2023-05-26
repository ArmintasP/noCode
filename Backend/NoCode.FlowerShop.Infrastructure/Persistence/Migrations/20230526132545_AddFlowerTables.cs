using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoCode.FlowerShop.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowersArrangementCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowersArrangementCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowersArrangements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    StorageQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    FlowerArrangementCategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowersArrangements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowersArrangements_FlowersArrangementCategories_FlowerArrangementCategoryId",
                        column: x => x.FlowerArrangementCategoryId,
                        principalTable: "FlowersArrangementCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowersArrangementsFlowers",
                columns: table => new
                {
                    FlowerArrangementId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FlowerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowersArrangementsFlowers", x => new { x.FlowerArrangementId, x.FlowerId });
                    table.ForeignKey(
                        name: "FK_FlowersArrangementsFlowers_FlowersArrangements_FlowerArrangementId",
                        column: x => x.FlowerArrangementId,
                        principalTable: "FlowersArrangements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowersArrangementsFlowers_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_Name",
                table: "Flowers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlowersArrangementCategories_Name",
                table: "FlowersArrangementCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlowersArrangements_FlowerArrangementCategoryId",
                table: "FlowersArrangements",
                column: "FlowerArrangementCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowersArrangements_Name",
                table: "FlowersArrangements",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlowersArrangementsFlowers_FlowerId",
                table: "FlowersArrangementsFlowers",
                column: "FlowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowersArrangementsFlowers");

            migrationBuilder.DropTable(
                name: "FlowersArrangements");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "FlowersArrangementCategories");
        }
    }
}
