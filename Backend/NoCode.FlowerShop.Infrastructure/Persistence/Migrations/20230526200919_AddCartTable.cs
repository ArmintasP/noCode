using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoCode.FlowerShop.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartFlowerArrangements",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FlowerArrangementId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartFlowerArrangements", x => new { x.CartId, x.FlowerArrangementId });
                    table.ForeignKey(
                        name: "FK_CartFlowerArrangements_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartFlowerArrangements_FlowersArrangements_FlowerArrangementId",
                        column: x => x.FlowerArrangementId,
                        principalTable: "FlowersArrangements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartFlowerArrangements_FlowerArrangementId",
                table: "CartFlowerArrangements",
                column: "FlowerArrangementId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartFlowerArrangements");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
