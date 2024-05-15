using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShopApp.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Product_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "IsDraft", "IsSoldOut", "Name", "Price", "ProductType", "Stock", "TotalSold", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { "15f7354f-e12b-4569-9dac-3a8e7bf12a83", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7779), "Strong and flavorful espresso shot", false, false, false, "Espresso", 2.99m, 0, 50, 100, "", null },
                    { "2e540eab-d664-4325-bbc6-4154d6501842", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7954), "Espresso with a dollop of frothy milk", false, false, false, "Macchiato", 3.79m, 0, 25, 60, "", null },
                    { "46823f9c-ac61-4e4f-9941-2583e50790ab", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7963), "Espresso with vanilla syrup, steamed milk, and caramel drizzle", false, false, false, "Caramel Macchiato", 4.99m, 0, 20, 50, "", null },
                    { "49394773-cac9-4210-95f6-1726423ae212", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7976), "Refreshing green tea", false, false, false, "Green Tea", 2.49m, 1, 30, 70, "", null },
                    { "586c8289-0730-4a78-8099-4c22ccc4e582", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7983), "Rich and creamy hot chocolate", false, false, false, "Hot Chocolate", 3.99m, 1, 25, 60, "", null },
                    { "66be0787-9066-4e8f-993c-192511b81b9f", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7846), "Traditional Italian espresso drink with frothy milk", false, false, false, "Cappuccino", 3.49m, 0, 30, 80, "", null },
                    { "6a38b9c2-a92b-4c01-a985-84926478e640", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7862), "A shot of espresso with hot water", false, false, false, "Americano", 3.29m, 0, 45, 110, "", null },
                    { "d0af4012-91a4-47af-8030-84f1457e79bf", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7816), "Smooth and creamy latte with steamed milk", false, false, false, "Latte", 3.99m, 0, 40, 90, "", null },
                    { "d3fd0e83-8020-4a06-947a-b8327fbc8209", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7855), "Rich and indulgent chocolate-flavored espresso drink", false, false, false, "Mocha", 4.49m, 0, 35, 70, "", null },
                    { "f447bb5c-a8ac-4cfa-88bc-12f01999c5fb", "", new DateTime(2024, 3, 1, 3, 24, 16, 960, DateTimeKind.Local).AddTicks(7970), "Chilled coffee served over ice", false, false, false, "Iced Coffee", 3.49m, 0, 60, 120, "", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "766d4aaf-ae4d-4731-8000-25f66737ae36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96d2e2ee-fa67-4e3d-ba94-4d69b2c91f7d");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "15f7354f-e12b-4569-9dac-3a8e7bf12a83");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2e540eab-d664-4325-bbc6-4154d6501842");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "46823f9c-ac61-4e4f-9941-2583e50790ab");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "49394773-cac9-4210-95f6-1726423ae212");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "586c8289-0730-4a78-8099-4c22ccc4e582");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "66be0787-9066-4e8f-993c-192511b81b9f");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6a38b9c2-a92b-4c01-a985-84926478e640");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d0af4012-91a4-47af-8030-84f1457e79bf");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d3fd0e83-8020-4a06-947a-b8327fbc8209");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f447bb5c-a8ac-4cfa-88bc-12f01999c5fb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4afff6b7-4ddd-419f-8d09-d8d0756ae94b", null, "client", "CLIENT" },
                    { "acb2bcdb-7ad0-4112-95e3-907b5f63dee9", null, "admin", "ADMIN" }
                });
        }
    }
}
