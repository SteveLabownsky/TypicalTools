using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TypicalTechTools.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    ProductCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "ProductDescription", "ProductName", "ProductPrice", "Updated" },
                values: new object[,]
                {
                    { 12345, "bluetooth headphones with fair battery life and a 1 month warranty", "Generic Headphones", 84.99m, new DateTime(2026, 4, 3, 16, 2, 18, 73, DateTimeKind.Local).AddTicks(2782) },
                    { 12346, "bluetooth headphones with good battery life and a 6 month warranty", "Expensive Headphones", 149.99m, new DateTime(2026, 4, 3, 16, 2, 18, 73, DateTimeKind.Local).AddTicks(2799) },
                    { 12347, "bluetooth headphones with good battery life and a 12 month warranty", "Name Brand Headphones", 199.99m, new DateTime(2026, 4, 3, 16, 2, 18, 73, DateTimeKind.Local).AddTicks(2800) },
                    { 12348, "simple bluetooth pointing device", "Generic Wireless Mouse", 39.99m, new DateTime(2026, 4, 3, 16, 2, 18, 73, DateTimeKind.Local).AddTicks(2801) },
                    { 12349, "mouse and keyboard wired combination", "Logitach Mouse and Keyboard", 73.99m, new DateTime(2026, 4, 3, 16, 2, 18, 73, DateTimeKind.Local).AddTicks(2802) },
                    { 12350, "quality wireless mouse", "Logitach Wireless Mouse", 149.99m, new DateTime(2026, 4, 3, 16, 2, 18, 73, DateTimeKind.Local).AddTicks(2803) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductCode", "ReviewText" },
                values: new object[,]
                {
                    { 1, 12345, "This is a great product. Highly Recommended." },
                    { 2, 12350, "Not worth the excessive price. Stick with a cheaper generic one." },
                    { 3, 12345, "A great budget buy. As good as some of the expensive alternatives." },
                    { 4, 12347, "Total garbage. Never buying this brand again!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
