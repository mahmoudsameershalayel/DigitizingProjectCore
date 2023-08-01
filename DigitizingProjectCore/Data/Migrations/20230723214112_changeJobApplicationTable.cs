using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeJobApplicationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "729c3f4e-978d-4f4f-96ef-b51cf599f3d8", new DateTime(2023, 7, 24, 0, 41, 12, 608, DateTimeKind.Local).AddTicks(78), "AQAAAAIAAYagAAAAEDhKQnuAr7NCNW0hAaAlRLxleIHKhRQKGE3LwDlaEYkOoc7W16Ap0C0m3Mc4euqCBg==", "68c61326-9a84-485b-a1ce-eb617118c2a7", new DateTime(2023, 7, 24, 0, 41, 12, 608, DateTimeKind.Local).AddTicks(128) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "b4999eab-94aa-4778-b8ce-d27108e7896a", new DateTime(2023, 7, 23, 11, 25, 27, 835, DateTimeKind.Local).AddTicks(8377), "AQAAAAIAAYagAAAAEKqekqI9fdazUpByR9lw5UUCjLA+A7pxYwAUOmILGT1+LJg/8ja7c8NZjsJYxADXqA==", "959b3fed-130f-4932-a7dc-2d393536ede4", new DateTime(2023, 7, 23, 11, 25, 27, 835, DateTimeKind.Local).AddTicks(8424) });
        }
    }
}
