using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnNameInServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CategoryForServices__CategoryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services__CategoryId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "_CategoryId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceCategoryId",
                table: "Services",
                newName: "CategoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "150b3b06-5cd5-45fd-a2a4-b8c3d6136053", new DateTime(2023, 7, 10, 3, 2, 16, 479, DateTimeKind.Local).AddTicks(1479), "AQAAAAIAAYagAAAAEFvoMD32ZZQz7r/7FbrsbEPHewVA81Oxf4ARXGA9lkphzuQJ3FVCjzS1FeEL5OTYmA==", "ab4e13d1-629f-45e5-aa94-48d6bfad1bde", new DateTime(2023, 7, 10, 3, 2, 16, 479, DateTimeKind.Local).AddTicks(1524) });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CategoryForServices_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "CategoryForServices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CategoryForServices_CategoryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CategoryId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Services",
                newName: "ServiceCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "_CategoryId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "2b09a222-45e9-4cfd-a7e8-1a932de759fe", new DateTime(2023, 7, 9, 11, 55, 42, 535, DateTimeKind.Local).AddTicks(1910), "AQAAAAIAAYagAAAAEL8MjqrjTO3FJskRjLpA8QUrrKj3cf44g8c3gsqdd2/3Lrnv29W57uBTnlRSe5QkTw==", "ff2ed226-6761-4176-b79f-311ab3a75c43", new DateTime(2023, 7, 9, 11, 55, 42, 535, DateTimeKind.Local).AddTicks(1963) });

            migrationBuilder.CreateIndex(
                name: "IX_Services__CategoryId",
                table: "Services",
                column: "_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CategoryForServices__CategoryId",
                table: "Services",
                column: "_CategoryId",
                principalTable: "CategoryForServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
