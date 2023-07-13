using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnsNameInNewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_CategoryForNews__CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News__CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "_CategoryId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "NewsCategoryId",
                table: "News",
                newName: "CategoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "566f5c78-3bb5-4e90-bb92-dea2d9454fca", new DateTime(2023, 7, 11, 6, 47, 28, 257, DateTimeKind.Local).AddTicks(4161), "AQAAAAIAAYagAAAAEMor4t7KMdGqO9uDIvKXuq5mlbngAL1QWGyiaWeFkbB0ah5XI6xKpvvPpk1Ilz2EEg==", "44421618-5d61-40e0-870c-987059ac306f", new DateTime(2023, 7, 11, 6, 47, 28, 257, DateTimeKind.Local).AddTicks(4216) });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_CategoryForNews_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "CategoryForNews",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_CategoryForNews_CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "News",
                newName: "NewsCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "_CategoryId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "40b207c7-01af-43f9-b384-b60f3d26e8fe", new DateTime(2023, 7, 11, 4, 49, 31, 313, DateTimeKind.Local).AddTicks(4371), "AQAAAAIAAYagAAAAED9d3mIHy4D7/nGEZMs8TBC0epgtB6uMDfhH8g4bj1ivIbXaexwh//G46eHFMr8peQ==", "0b0ecaf2-3366-41a9-8227-7966b691f616", new DateTime(2023, 7, 11, 4, 49, 31, 313, DateTimeKind.Local).AddTicks(4420) });

            migrationBuilder.CreateIndex(
                name: "IX_News__CategoryId",
                table: "News",
                column: "_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_CategoryForNews__CategoryId",
                table: "News",
                column: "_CategoryId",
                principalTable: "CategoryForNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
