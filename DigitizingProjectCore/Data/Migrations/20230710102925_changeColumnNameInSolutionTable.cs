using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnNameInSolutionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_CategoryForProducts__CategoryId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions__CategoryId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "_CategoryId",
                table: "Solutions");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Solutions",
                newName: "CategoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "c77a69a6-9c7d-4243-b358-a48a5f55b1e0", new DateTime(2023, 7, 10, 13, 29, 25, 566, DateTimeKind.Local).AddTicks(9277), "AQAAAAIAAYagAAAAEOEMGoXY6N0dTGqHQLTm45E6orOoQw0msLxMLPCpbB6DQynkXUScbZzT1yJwhNLu0A==", "9088a0d5-de6a-4ae6-93ad-b30ccf149f41", new DateTime(2023, 7, 10, 13, 29, 25, 566, DateTimeKind.Local).AddTicks(9334) });

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_CategoryId",
                table: "Solutions",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_CategoryForProducts_CategoryId",
                table: "Solutions",
                column: "CategoryId",
                principalTable: "CategoryForProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_CategoryForProducts_CategoryId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_CategoryId",
                table: "Solutions");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Solutions",
                newName: "ProductCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "_CategoryId",
                table: "Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "1e65bf08-3d12-4026-a1ee-5e530d8d2312", new DateTime(2023, 7, 10, 4, 54, 32, 105, DateTimeKind.Local).AddTicks(2277), "AQAAAAIAAYagAAAAEEUSqdRkZTQrwahx6gaYGJMweVA82Tt3/oYJq+uUN+ZL+lnqEipkOhkjL5kpTE8G0g==", "8e9bc04a-de33-4f86-8fd0-dbf8e58e6909", new DateTime(2023, 7, 10, 4, 54, 32, 105, DateTimeKind.Local).AddTicks(2329) });

            migrationBuilder.CreateIndex(
                name: "IX_Solutions__CategoryId",
                table: "Solutions",
                column: "_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_CategoryForProducts__CategoryId",
                table: "Solutions",
                column: "_CategoryId",
                principalTable: "CategoryForProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
