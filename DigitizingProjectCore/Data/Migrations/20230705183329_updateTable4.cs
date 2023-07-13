using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PDFFile",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LogoImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocFile",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "f5270ca5-3dc3-4de5-a31e-4449e420416e", new DateTime(2023, 7, 5, 21, 33, 29, 262, DateTimeKind.Local).AddTicks(4372), "AQAAAAIAAYagAAAAEAhjSvf+Vyh/fBtwrAeedqr8V8NO7S4MKeu8qs1qJl5PbAvjkf4HGvJjyBJsmTaGgw==", "d6524963-634d-40dc-9237-27b4e34d95ef", new DateTime(2023, 7, 5, 21, 33, 29, 262, DateTimeKind.Local).AddTicks(4434) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PDFFile",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocFile",
                table: "Products",
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
                values: new object[] { "0b79885f-8223-47d1-a303-cd958ce94d17", new DateTime(2023, 7, 5, 19, 20, 52, 485, DateTimeKind.Local).AddTicks(4330), "AQAAAAIAAYagAAAAEED3daza8WmsiygFGAcHVHAidIzLiLVDwNHjfTyVArSceOPSEbU5ihYgrYkl/788aw==", "9be6549c-9e25-430c-9322-a6aa663e80b3", new DateTime(2023, 7, 5, 19, 20, 52, 485, DateTimeKind.Local).AddTicks(4385) });
        }
    }
}
