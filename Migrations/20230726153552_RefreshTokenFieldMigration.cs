using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobHuntApi.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenFieldMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "983fc3ac-d3b9-4ae9-9732-4a9bdfd64b4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4e64f72-d297-4347-9b76-176ab589f86b");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09ca2cd9-c5e6-42df-badd-aeef81fccc74", null, "User", "USER" },
                    { "e8f5de9d-b4cf-4732-be7e-d5944abb43e2", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09ca2cd9-c5e6-42df-badd-aeef81fccc74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f5de9d-b4cf-4732-be7e-d5944abb43e2");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "983fc3ac-d3b9-4ae9-9732-4a9bdfd64b4b", null, "Administrator", "ADMINISTRATOR" },
                    { "f4e64f72-d297-4347-9b76-176ab589f86b", null, "User", "USER" }
                });
        }
    }
}
