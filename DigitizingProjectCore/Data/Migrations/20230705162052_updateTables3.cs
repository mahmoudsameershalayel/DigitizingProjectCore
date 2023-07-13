using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Solutions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Distributors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "CategoryForServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "CategoryForProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "CategoryForNews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "0b79885f-8223-47d1-a303-cd958ce94d17", new DateTime(2023, 7, 5, 19, 20, 52, 485, DateTimeKind.Local).AddTicks(4330), "AQAAAAIAAYagAAAAEED3daza8WmsiygFGAcHVHAidIzLiLVDwNHjfTyVArSceOPSEbU5ihYgrYkl/788aw==", "9be6549c-9e25-430c-9322-a6aa663e80b3", new DateTime(2023, 7, 5, 19, 20, 52, 485, DateTimeKind.Local).AddTicks(4385) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
