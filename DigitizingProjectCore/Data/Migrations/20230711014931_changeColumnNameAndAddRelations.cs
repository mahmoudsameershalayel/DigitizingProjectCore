using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnNameAndAddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionProducts_Products_ProductId",
                table: "SolutionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionProducts_Solutions_SolutionId",
                table: "SolutionProducts");

            migrationBuilder.AlterColumn<int>(
                name: "SolutionId",
                table: "SolutionProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SolutionProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "40b207c7-01af-43f9-b384-b60f3d26e8fe", new DateTime(2023, 7, 11, 4, 49, 31, 313, DateTimeKind.Local).AddTicks(4371), "AQAAAAIAAYagAAAAED9d3mIHy4D7/nGEZMs8TBC0epgtB6uMDfhH8g4bj1ivIbXaexwh//G46eHFMr8peQ==", "0b0ecaf2-3366-41a9-8227-7966b691f616", new DateTime(2023, 7, 11, 4, 49, 31, 313, DateTimeKind.Local).AddTicks(4420) });

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionProducts_Products_ProductId",
                table: "SolutionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionProducts_Solutions_SolutionId",
                table: "SolutionProducts",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionProducts_Products_ProductId",
                table: "SolutionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionProducts_Solutions_SolutionId",
                table: "SolutionProducts");

            migrationBuilder.AlterColumn<int>(
                name: "SolutionId",
                table: "SolutionProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SolutionProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "47bea095-719f-46b5-8a55-4fc9b4a02e55", new DateTime(2023, 7, 10, 13, 33, 10, 392, DateTimeKind.Local).AddTicks(332), "AQAAAAIAAYagAAAAEKj2mrnUJCD8cmceTu011779zGCZ5lJytBNXC0gfXJs8cNMsE7lpIKJrNnhefUdGgw==", "8d659bda-8c4f-435d-99d6-0874e5154dd6", new DateTime(2023, 7, 10, 13, 33, 10, 392, DateTimeKind.Local).AddTicks(389) });

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionProducts_Products_ProductId",
                table: "SolutionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionProducts_Solutions_SolutionId",
                table: "SolutionProducts",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id");
        }
    }
}
