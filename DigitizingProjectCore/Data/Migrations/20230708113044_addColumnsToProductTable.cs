using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnsToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailsAr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DetailsEn",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "d817dac6-7b89-491a-8b42-3305d8a1531c", new DateTime(2023, 7, 8, 14, 30, 44, 188, DateTimeKind.Local).AddTicks(1197), "AQAAAAIAAYagAAAAEKgqYasZkHhyPIo6PeZXmfi1hOjW+rQU+q33FsoKa6wCYKWCXJB+yqmTNi9DFA7uuA==", "e68d2c65-a743-42c2-ad7e-f59542f5d744", new DateTime(2023, 7, 8, 14, 30, 44, 188, DateTimeKind.Local).AddTicks(1280) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailsAr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DetailsEn",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "6ce69326-d4cc-427e-843e-ec7d64d73d84", new DateTime(2023, 7, 8, 1, 12, 33, 951, DateTimeKind.Local).AddTicks(8465), "AQAAAAIAAYagAAAAEEttAWIz9VzhNGAvYYCUTLrHutqaJ5Pk+6mfMdgID8hr2MnOW4t1EgBGw17EgViiHQ==", "67105bee-d809-4bde-b70a-9b38f76f1155", new DateTime(2023, 7, 8, 1, 12, 33, 951, DateTimeKind.Local).AddTicks(8800) });
        }
    }
}
