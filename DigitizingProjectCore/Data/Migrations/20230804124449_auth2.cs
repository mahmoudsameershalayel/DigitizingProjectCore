using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class auth2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "0bd0f2ce-cd5d-4ee2-bb40-9391b3fce9e2", new DateTime(2023, 8, 4, 15, 44, 49, 16, DateTimeKind.Local).AddTicks(6072), "Admin@admin.com", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKJz19xkxIvzmkvGBm/qmg9T+TdTFn1hHjqT6lBE/oQT+sdLY/6Cn0qKYhq5hHZNdg==", "f3fd7733-90a8-44af-99e5-c7a41a529c3b", new DateTime(2023, 8, 4, 15, 44, 49, 16, DateTimeKind.Local).AddTicks(6127) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "48db4e8c-78e7-4f95-920e-36c77a78e07f", new DateTime(2023, 8, 4, 15, 28, 3, 930, DateTimeKind.Local).AddTicks(1760), "Administrator@admin.com", "ADMINISTRATOR@ADMIN.COM", "AQAAAAIAAYagAAAAEAQJBYpuhcBszHa3XRkYZuqbJ2BBvF3zu+T9RzYJQcdblHBS0/U9RdPfhB/oBJBJjw==", "f9bcb528-7409-4be2-994e-6f55bc37930c", new DateTime(2023, 8, 4, 15, 28, 3, 930, DateTimeKind.Local).AddTicks(1806) });
        }
    }
}
