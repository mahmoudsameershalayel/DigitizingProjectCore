using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createAboutUsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "725d7e86-18f4-4451-b2d5-f3d12a1a7b69", new DateTime(2023, 7, 18, 12, 3, 59, 34, DateTimeKind.Local).AddTicks(3604), "AQAAAAIAAYagAAAAEJCwSlssO6qaePo156YKcf+8OTPqM54Ip3iA3iU2+YDc9EF6mUzK9tnDZH/KTBiS3A==", "6a3426e6-eeb1-4fa2-ab2a-d9d65060d74d", new DateTime(2023, 7, 18, 12, 3, 59, 34, DateTimeKind.Local).AddTicks(3658) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "080eb7d5-5f6f-486e-a918-2fd9698417c3", new DateTime(2023, 7, 17, 11, 47, 23, 214, DateTimeKind.Local).AddTicks(6426), "AQAAAAIAAYagAAAAEHgYxx5LgH3BOvUJu9YLClPJuAqesGd71LD/xm00aYU4eta2eYTEbjNXGRL8TMQHNg==", "313253a7-f4f3-4f59-9058-1eb7552d2ff5", new DateTime(2023, 7, 17, 11, 47, 23, 214, DateTimeKind.Local).AddTicks(6510) });
        }
    }
}
