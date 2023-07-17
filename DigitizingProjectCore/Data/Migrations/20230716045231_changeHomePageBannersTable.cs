using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeHomePageBannersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "HomePageBanners");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "HomePageBanners",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "HomePageBanners",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageName",
                table: "HomePageBanners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "5f6ff2f2-63b8-44a6-93fd-2f41aeb0c7d8", new DateTime(2023, 7, 16, 7, 52, 31, 152, DateTimeKind.Local).AddTicks(7620), "AQAAAAIAAYagAAAAENxIydgMXLgRoM1jehhU2VjCo9HSGl6C9OpmsnnwTokenefRSlaRM6cCCHeA9tGtWA==", "c22d0091-1152-4603-ac21-3efff0b6dc8d", new DateTime(2023, 7, 16, 7, 52, 31, 152, DateTimeKind.Local).AddTicks(8151) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImageName",
                table: "HomePageBanners");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "HomePageBanners",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "HomePageBanners",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "HomePageBanners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "9835c06a-e462-4850-b4c2-8da83b55e5c3", new DateTime(2023, 7, 16, 7, 45, 28, 90, DateTimeKind.Local).AddTicks(2351), "AQAAAAIAAYagAAAAEDM0V4QvWFtfNlrUGYPjfDX5nK7XopQdBTpX69RL9ViIi110cF24t2LST7j6vbb9iA==", "9719eed3-e54a-4d82-9603-cdcbe8cf13b0", new DateTime(2023, 7, 16, 7, 45, 28, 90, DateTimeKind.Local).AddTicks(2414) });
        }
    }
}
