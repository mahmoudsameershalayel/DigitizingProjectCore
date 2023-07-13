using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeNewsConstrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LogoImageName",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "1aa56836-be1d-4f7f-a81b-81712b53595e", new DateTime(2023, 7, 11, 7, 29, 58, 504, DateTimeKind.Local).AddTicks(3801), "AQAAAAIAAYagAAAAEG0kUhCHe7O5hat0joLix8Mg1T5u1WaH+VVrimBewTkjA+QhE73xBjGxHGp47r6KCg==", "05bf349a-c83f-4ae3-a509-5e82c8a0bb5b", new DateTime(2023, 7, 11, 7, 29, 58, 504, DateTimeKind.Local).AddTicks(3860) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LogoImageName",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "6f4567ab-1746-42a3-ab7f-93a117f02c57", new DateTime(2023, 7, 11, 6, 53, 4, 834, DateTimeKind.Local).AddTicks(2404), "AQAAAAIAAYagAAAAEOy/ikp55+NYkfZxlkGY9E2E8QmVABLZCuwmQ9G+o7W6aqunDKYDSBfFn33kq66C7g==", "b39a2160-1693-4e48-8a47-845fd6fe2ecf", new DateTime(2023, 7, 11, 6, 53, 4, 834, DateTimeKind.Local).AddTicks(2453) });
        }
    }
}
