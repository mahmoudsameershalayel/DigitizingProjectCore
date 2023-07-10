using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnNameInSolutionTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PDFFile",
                table: "Solutions",
                newName: "PDFFileName");

            migrationBuilder.RenameColumn(
                name: "LogoImage",
                table: "Solutions",
                newName: "LogoImageName");

            migrationBuilder.RenameColumn(
                name: "DocFile",
                table: "Solutions",
                newName: "DocFileName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "47bea095-719f-46b5-8a55-4fc9b4a02e55", new DateTime(2023, 7, 10, 13, 33, 10, 392, DateTimeKind.Local).AddTicks(332), "AQAAAAIAAYagAAAAEKj2mrnUJCD8cmceTu011779zGCZ5lJytBNXC0gfXJs8cNMsE7lpIKJrNnhefUdGgw==", "8d659bda-8c4f-435d-99d6-0874e5154dd6", new DateTime(2023, 7, 10, 13, 33, 10, 392, DateTimeKind.Local).AddTicks(389) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PDFFileName",
                table: "Solutions",
                newName: "PDFFile");

            migrationBuilder.RenameColumn(
                name: "LogoImageName",
                table: "Solutions",
                newName: "LogoImage");

            migrationBuilder.RenameColumn(
                name: "DocFileName",
                table: "Solutions",
                newName: "DocFile");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "c77a69a6-9c7d-4243-b358-a48a5f55b1e0", new DateTime(2023, 7, 10, 13, 29, 25, 566, DateTimeKind.Local).AddTicks(9277), "AQAAAAIAAYagAAAAEOEMGoXY6N0dTGqHQLTm45E6orOoQw0msLxMLPCpbB6DQynkXUScbZzT1yJwhNLu0A==", "9088a0d5-de6a-4ae6-93ad-b30ccf149f41", new DateTime(2023, 7, 10, 13, 29, 25, 566, DateTimeKind.Local).AddTicks(9334) });
        }
    }
}
