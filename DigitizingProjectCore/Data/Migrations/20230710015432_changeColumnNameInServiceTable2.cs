using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnNameInServiceTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PDFFile",
                table: "Services",
                newName: "PDFFileName");

            migrationBuilder.RenameColumn(
                name: "LogoImage",
                table: "Services",
                newName: "LogoImageName");

            migrationBuilder.RenameColumn(
                name: "DocFile",
                table: "Services",
                newName: "DocFileName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "1e65bf08-3d12-4026-a1ee-5e530d8d2312", new DateTime(2023, 7, 10, 4, 54, 32, 105, DateTimeKind.Local).AddTicks(2277), "AQAAAAIAAYagAAAAEEUSqdRkZTQrwahx6gaYGJMweVA82Tt3/oYJq+uUN+ZL+lnqEipkOhkjL5kpTE8G0g==", "8e9bc04a-de33-4f86-8fd0-dbf8e58e6909", new DateTime(2023, 7, 10, 4, 54, 32, 105, DateTimeKind.Local).AddTicks(2329) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PDFFileName",
                table: "Services",
                newName: "PDFFile");

            migrationBuilder.RenameColumn(
                name: "LogoImageName",
                table: "Services",
                newName: "LogoImage");

            migrationBuilder.RenameColumn(
                name: "DocFileName",
                table: "Services",
                newName: "DocFile");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "150b3b06-5cd5-45fd-a2a4-b8c3d6136053", new DateTime(2023, 7, 10, 3, 2, 16, 479, DateTimeKind.Local).AddTicks(1479), "AQAAAAIAAYagAAAAEFvoMD32ZZQz7r/7FbrsbEPHewVA81Oxf4ARXGA9lkphzuQJ3FVCjzS1FeEL5OTYmA==", "ab4e13d1-629f-45e5-aa94-48d6bfad1bde", new DateTime(2023, 7, 10, 3, 2, 16, 479, DateTimeKind.Local).AddTicks(1524) });
        }
    }
}
