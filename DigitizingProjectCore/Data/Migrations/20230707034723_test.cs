using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryForProducts__CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products__CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategoryForProductId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "9017f86f-8582-4a63-b3b7-4a6722842347", new DateTime(2023, 7, 7, 6, 47, 23, 474, DateTimeKind.Local).AddTicks(5013), "AQAAAAIAAYagAAAAEAUG6UtlSxqHJc+bTqki3Suc0AEkA3btLtWnpnF3vUVPUlDAPY8Ytc7rCv2VBDL5LQ==", "18aa01c1-35dd-4ea3-a6b3-254daae0586d", new DateTime(2023, 7, 7, 6, 47, 23, 474, DateTimeKind.Local).AddTicks(5064) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryForProductId",
                table: "Products",
                column: "CategoryForProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryForProducts_CategoryForProductId",
                table: "Products",
                column: "CategoryForProductId",
                principalTable: "CategoryForProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryForProducts_CategoryForProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryForProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryForProductId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "_CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "927fa633-24aa-4a94-9622-7e1013027e87", new DateTime(2023, 7, 7, 6, 29, 26, 988, DateTimeKind.Local).AddTicks(9316), "AQAAAAIAAYagAAAAECn/9QgRNh1xjjW0rmn5BLxK+xsRCXb5rJRUWRgwf+DFefkFfOYyIAZmJYaG4pLnjA==", "b2c29b63-ee5e-47b3-a800-4f60a9c835d3", new DateTime(2023, 7, 7, 6, 29, 26, 988, DateTimeKind.Local).AddTicks(9373) });

            migrationBuilder.CreateIndex(
                name: "IX_Products__CategoryId",
                table: "Products",
                column: "_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryForProducts__CategoryId",
                table: "Products",
                column: "_CategoryId",
                principalTable: "CategoryForProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
