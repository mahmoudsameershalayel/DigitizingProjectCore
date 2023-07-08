using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryForProducts_CategoryForProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryForProductId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryForProductId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "eb902a0a-5162-44b8-96aa-ee37e753d99d", new DateTime(2023, 7, 7, 6, 49, 18, 415, DateTimeKind.Local).AddTicks(4651), "AQAAAAIAAYagAAAAEPMYopUHbE+opYTQWHvBr+oqrkbK61yPEL52sTDDVXkf1U5CfG+yZz0dkotGUOXH1Q==", "cb4b99da-25b9-46ba-abd5-767ab41b5037", new DateTime(2023, 7, 7, 6, 49, 18, 415, DateTimeKind.Local).AddTicks(4883) });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryForProducts_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "CategoryForProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryForProducts_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategoryForProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryForProductId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "9017f86f-8582-4a63-b3b7-4a6722842347", new DateTime(2023, 7, 7, 6, 47, 23, 474, DateTimeKind.Local).AddTicks(5013), "AQAAAAIAAYagAAAAEAUG6UtlSxqHJc+bTqki3Suc0AEkA3btLtWnpnF3vUVPUlDAPY8Ytc7rCv2VBDL5LQ==", "18aa01c1-35dd-4ea3-a6b3-254daae0586d", new DateTime(2023, 7, 7, 6, 47, 23, 474, DateTimeKind.Local).AddTicks(5064) });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryForProducts_CategoryForProductId",
                table: "Products",
                column: "CategoryForProductId",
                principalTable: "CategoryForProducts",
                principalColumn: "Id");
        }
    }
}
