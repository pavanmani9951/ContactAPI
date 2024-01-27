using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactAPI.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "CreatedDate", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Sap", new DateTime(2024, 1, 27, 16, 29, 2, 861, DateTimeKind.Local).AddTicks(978), "Pavan", "manikanta", 9951658045L },
                    { 2, "GNT", new DateTime(2024, 1, 27, 16, 29, 2, 861, DateTimeKind.Local).AddTicks(1001), "Harini", "Devathi", 9381272144L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
