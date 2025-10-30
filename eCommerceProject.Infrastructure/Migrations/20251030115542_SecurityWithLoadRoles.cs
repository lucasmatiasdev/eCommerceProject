using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecurityWithLoadRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d8f77e7-1bdc-41e7-9552-7ed86616cfad", null, "Admin", "ADMIN" },
                    { "d18912af-cad1-4ad4-9617-be3564c31196", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d8f77e7-1bdc-41e7-9552-7ed86616cfad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d18912af-cad1-4ad4-9617-be3564c31196");
        }
    }
}
