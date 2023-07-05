using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Distributors");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "CategoryForServices");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "CategoryForProducts");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "CategoryForNews");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Brands");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "54db1a36-2940-438c-ad71-9f31f5cb459d", new DateTime(2023, 7, 5, 19, 20, 10, 216, DateTimeKind.Local).AddTicks(9759), "AQAAAAIAAYagAAAAEAWQ9920gxNo92ie5LZyg9JvXhU81wMgFQwp4kEVk7GZEy8J1HV3cKCtsX7olJ8dNw==", "a9ab038c-bf0e-4ab4-8c71-ab47a8de22a6", new DateTime(2023, 7, 5, 19, 20, 10, 216, DateTimeKind.Local).AddTicks(9815) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "Distributors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "CategoryForServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "CategoryForProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "CategoryForNews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Created_At",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "dbb89b77-409d-460c-94de-8adb49fe2f91", new DateTime(2023, 7, 5, 17, 56, 28, 213, DateTimeKind.Local).AddTicks(6795), "AQAAAAIAAYagAAAAEEyVUHHIxQEUBHZCTgalpxLV+gAaG9L/5l2evCRKJ6511w8jXVyVKOCESmnHybnJVg==", "27ee3b49-516d-48cb-8694-0874f566df84", new DateTime(2023, 7, 5, 17, 56, 28, 213, DateTimeKind.Local).AddTicks(6842) });
        }
    }
}
