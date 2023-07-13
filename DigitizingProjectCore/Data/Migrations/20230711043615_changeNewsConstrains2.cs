using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeNewsConstrains2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TagsEn",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TagsAr",
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
                values: new object[] { "5995385c-c1d9-49cf-97a5-aceac5a5ebae", new DateTime(2023, 7, 11, 7, 36, 15, 279, DateTimeKind.Local).AddTicks(9635), "AQAAAAIAAYagAAAAEBwUnNH49xYPwQOhUdm6mkYNSy/f27zAmpk7ib+DqS7KUVlNRkRK2DEf6bX70H6OTA==", "6095bb55-ca0a-480e-b001-9f8ce10930d1", new DateTime(2023, 7, 11, 7, 36, 15, 279, DateTimeKind.Local).AddTicks(9699) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TagsEn",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TagsAr",
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
                values: new object[] { "1aa56836-be1d-4f7f-a81b-81712b53595e", new DateTime(2023, 7, 11, 7, 29, 58, 504, DateTimeKind.Local).AddTicks(3801), "AQAAAAIAAYagAAAAEG0kUhCHe7O5hat0joLix8Mg1T5u1WaH+VVrimBewTkjA+QhE73xBjGxHGp47r6KCg==", "05bf349a-c83f-4ae3-a509-5e82c8a0bb5b", new DateTime(2023, 7, 11, 7, 29, 58, 504, DateTimeKind.Local).AddTicks(3860) });
        }
    }
}
