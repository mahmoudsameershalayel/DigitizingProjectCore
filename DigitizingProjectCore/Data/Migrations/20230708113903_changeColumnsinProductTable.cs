using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnsinProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PDFFile",
                table: "Products",
                newName: "PDFFileName");

            migrationBuilder.RenameColumn(
                name: "LogoImage",
                table: "Products",
                newName: "LogoImageName");

            migrationBuilder.RenameColumn(
                name: "DocFile",
                table: "Products",
                newName: "DocFileName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "e93620ac-24e4-4392-9ba2-3a3830ac03fb", new DateTime(2023, 7, 8, 14, 39, 2, 887, DateTimeKind.Local).AddTicks(1847), "AQAAAAIAAYagAAAAEIsBRi4efa4HjEdFM9k8Zz15TQ43aV1TE/vwkzDEkgiwnfNrkHJ2rjqxLuApv4887w==", "50414b01-1bb6-44e2-a637-7701b87a29db", new DateTime(2023, 7, 8, 14, 39, 2, 887, DateTimeKind.Local).AddTicks(1901) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PDFFileName",
                table: "Products",
                newName: "PDFFile");

            migrationBuilder.RenameColumn(
                name: "LogoImageName",
                table: "Products",
                newName: "LogoImage");

            migrationBuilder.RenameColumn(
                name: "DocFileName",
                table: "Products",
                newName: "DocFile");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "d817dac6-7b89-491a-8b42-3305d8a1531c", new DateTime(2023, 7, 8, 14, 30, 44, 188, DateTimeKind.Local).AddTicks(1197), "AQAAAAIAAYagAAAAEKgqYasZkHhyPIo6PeZXmfi1hOjW+rQU+q33FsoKa6wCYKWCXJB+yqmTNi9DFA7uuA==", "e68d2c65-a743-42c2-ad7e-f59542f5d744", new DateTime(2023, 7, 8, 14, 30, 44, 188, DateTimeKind.Local).AddTicks(1280) });
        }
    }
}
