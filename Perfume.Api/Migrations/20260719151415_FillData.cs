using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Perfume.Api.Migrations
{
    /// <inheritdoc />
    public partial class FillData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "NameAr", "NameEn", "Price" },
                values: new object[,]
                {
                    { 1, "Fresh spicy", "~/images/sau.jpg", "سوفاج", "Sauvage", 64.00m },
                    { 2, "Warm sweet", "~/images/swy.jpg", "سترونجر ويذ يو", "Stronger With You", 95.00m },
                    { 3, "Woody aromatic", "~/images/channel.jpg", "بلو دي شانيل", "Blue De Cannel", 45.00m },
                    { 4, "Citrus fresh", "~/images/silver.jpg", "سيلفر سينت", "Silver Scent", 78.00m },
                    { 5, "Nice smell", "~/images/boss.jpg", "بوس", "Boss Bottled", 33.00m }
                });
        }

        /// <inheritdoc />
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
