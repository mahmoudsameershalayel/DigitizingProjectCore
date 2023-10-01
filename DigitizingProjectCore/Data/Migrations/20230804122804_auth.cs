using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "48db4e8c-78e7-4f95-920e-36c77a78e07f", new DateTime(2023, 8, 4, 15, 28, 3, 930, DateTimeKind.Local).AddTicks(1760), "AQAAAAIAAYagAAAAEAQJBYpuhcBszHa3XRkYZuqbJ2BBvF3zu+T9RzYJQcdblHBS0/U9RdPfhB/oBJBJjw==", "f9bcb528-7409-4be2-994e-6f55bc37930c", new DateTime(2023, 8, 4, 15, 28, 3, 930, DateTimeKind.Local).AddTicks(1806) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "48458799-9b1b-45e4-909f-c8d6319507b8", new DateTime(2023, 7, 24, 11, 10, 16, 43, DateTimeKind.Local).AddTicks(4818), "AQAAAAIAAYagAAAAEOvwooCidltVHYDsyQkwU8NYSu8Csu1kuNvcnkKBn0SbJWePM2jyHvv97NPqLLrLqQ==", "08e3c8cc-f435-46a1-9563-2aaf245c867f", new DateTime(2023, 7, 24, 11, 10, 16, 43, DateTimeKind.Local).AddTicks(4878) });
        }
    }
}
