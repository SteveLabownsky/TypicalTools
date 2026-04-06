using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TypicalTechTools.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<int>(type: "int", nullable: false),
                    ReviewCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "ProductDescription", "ProductName", "ProductPrice", "Updated" },
                values: new object[,]
                {
                    { 12345, "bluetooth headphones with fair battery life and a 1 month warranty", "Generic Headphones", 84.99m, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4823) },
                    { 12346, "bluetooth headphones with good battery life and a 6 month warranty", "Expensive Headphones", 149.99m, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4843) },
                    { 12347, "bluetooth headphones with good battery life and a 12 month warranty", "Name Brand Headphones", 199.99m, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4844) },
                    { 12348, "simple bluetooth pointing device", "Generic Wireless Mouse", 39.99m, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4845) },
                    { 12349, "mouse and keyboard wired combination", "Logitach Mouse and Keyboard", 73.99m, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4846) },
                    { 12350, "quality wireless mouse", "Logitach Wireless Mouse", 149.99m, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4847) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductCode", "ReviewCreated", "ReviewText" },
                values: new object[,]
                {
                    { 1, 12345, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4963), "This is a great product. Highly Recommended." },
                    { 2, 12350, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4967), "Not worth the excessive price. Stick with a cheaper generic one." },
                    { 3, 12345, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4968), "A great budget buy. As good as some of the expensive alternatives." },
                    { 4, 12347, new DateTime(2026, 4, 6, 17, 45, 46, 199, DateTimeKind.Local).AddTicks(4969), "Total garbage. Never buying this brand again!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductCode",
                table: "Reviews",
                column: "ProductCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
