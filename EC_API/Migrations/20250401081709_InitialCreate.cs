using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EC_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Products = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "OMEN Gaming Laptop I9", "Laptop OEMN", 1200.99, 10 },
                    { 2, "HP Gaming Laptop I7", "Laptop HP", 999.99000000000001, 9 },
                    { 3, "DELL Gaming Laptop I5", "Laptop DELL", 899.99000000000001, 13 },
                    { 4, "APPLE Gaming Laptop MAC-AIR", "Laptop APPLE", 1599.99, 12 },
                    { 5, "ASUS Gaming Laptop I9", "Laptop ASUS", 1300.99, 11 },
                    { 6, "Smartphone Model I14", "Smartphone APPLE I14", 899.5, 25 },
                    { 7, "Smartphone Model I15", "Smartphone APPLE I15", 899.5, 35 },
                    { 8, "Smartphone Model I16", "Smartphone APPLE I16", 899.5, 40 },
                    { 9, "Smartphone Model OPPO3", "Smartphone OPPO", 899.5, 51 },
                    { 10, "Smartphone Model S23", "Smartphone SAMSUNG S23", 899.5, 20 },
                    { 11, "Smartphone Model S24", "Smartphone SAMSUNG S24", 899.5, 17 },
                    { 12, "Smartphone Model S25", "Smartphone SAMSUNG S25", 899.5, 15 },
                    { 13, "Noise Cancelling Headphone Model APPLE", "Headphone APPLE", 199.99000000000001, 55 },
                    { 14, "Noise Cancelling Headphone Model OPPO", "Headphone OPPO", 199.99000000000001, 45 },
                    { 15, "Headphone Model SAMSUNG", "Headphone SAMSUNG", 199.99000000000001, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
