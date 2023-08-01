using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changePagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Pages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Pages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "Pages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Pages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_By",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "48458799-9b1b-45e4-909f-c8d6319507b8", new DateTime(2023, 7, 24, 11, 10, 16, 43, DateTimeKind.Local).AddTicks(4818), "AQAAAAIAAYagAAAAEOvwooCidltVHYDsyQkwU8NYSu8Csu1kuNvcnkKBn0SbJWePM2jyHvv97NPqLLrLqQ==", "08e3c8cc-f435-46a1-9563-2aaf245c867f", new DateTime(2023, 7, 24, 11, 10, 16, 43, DateTimeKind.Local).AddTicks(4878) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "SortId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Updated_By",
                table: "Pages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "231e387b-ae08-41bd-98b5-afa8450fc130", new DateTime(2023, 7, 24, 1, 42, 16, 378, DateTimeKind.Local).AddTicks(9282), "AQAAAAIAAYagAAAAEN7bBBjK3Kx4PBGGjBHmf4weIPMu9Yh0FyHGY0slHUUxOm1pzmzZFKPanfnfMHMdIg==", "7e2195ab-59ee-4623-9213-b63587230c87", new DateTime(2023, 7, 24, 1, 42, 16, 378, DateTimeKind.Local).AddTicks(9340) });
        }
    }
}
