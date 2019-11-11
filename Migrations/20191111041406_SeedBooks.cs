using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryListManager.Migrations
{
    public partial class SeedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroceryList",
                columns: new[] { "Id", "Name", "Price", "PurchasedDate" },
                values: new object[,]
                {
                    { 1, "Cereal", "10$", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "Eggs", "6$", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "Apples", "9$", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "Milk", "9$", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, "Yogurt", "8$", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroceryList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroceryList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroceryList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GroceryList",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroceryList",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
