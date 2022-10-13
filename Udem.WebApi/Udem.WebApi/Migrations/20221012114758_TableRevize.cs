using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Udem.WebApi.Migrations
{
    public partial class TableRevize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 1, new DateTime(2022, 10, 11, 14, 47, 58, 419, DateTimeKind.Local).AddTicks(8223), null, "Telefon", 10000m, 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 2, new DateTime(2022, 10, 9, 14, 47, 58, 420, DateTimeKind.Local).AddTicks(9281), null, "Bilgisayar", 20000m, 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 3, new DateTime(2022, 10, 10, 14, 47, 58, 420, DateTimeKind.Local).AddTicks(9302), null, "Buzdolabı", 25000m, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
