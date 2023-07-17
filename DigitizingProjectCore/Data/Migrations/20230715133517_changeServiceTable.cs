using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PDFFileName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LogoImageName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocFileName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "11da41ff-62d0-46a7-90fa-a9da94c68855", new DateTime(2023, 7, 15, 16, 35, 17, 68, DateTimeKind.Local).AddTicks(159), "AQAAAAIAAYagAAAAEDG52iuUajZ/qo5aruBOONgUNuZlfPP/ry8tlU7tQNc33BwXP+eCo9ZP83MqrB/2wA==", "7554f0fc-9dfd-41df-8e04-0c6b5139c282", new DateTime(2023, 7, 15, 16, 35, 17, 68, DateTimeKind.Local).AddTicks(217) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PDFFileName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoImageName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocFileName",
                table: "Services",
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
                values: new object[] { "5d869256-4e2e-4ed3-ac7e-f8294b83cdd0", new DateTime(2023, 7, 15, 14, 29, 0, 48, DateTimeKind.Local).AddTicks(1452), "AQAAAAIAAYagAAAAENnpc6LBBr4M/IMyqDzKbGWfT5KRAz62Gdj7kfz4SULhvvNl/qh/XhQBXoMSKQ0uVw==", "f108724e-6101-4914-848e-1c096c07fed0", new DateTime(2023, 7, 15, 14, 29, 0, 48, DateTimeKind.Local).AddTicks(1500) });
        }
    }
}
