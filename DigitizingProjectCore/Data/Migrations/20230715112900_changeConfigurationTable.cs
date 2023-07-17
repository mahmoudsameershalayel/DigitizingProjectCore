using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeConfigurationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Configurations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "5d869256-4e2e-4ed3-ac7e-f8294b83cdd0", new DateTime(2023, 7, 15, 14, 29, 0, 48, DateTimeKind.Local).AddTicks(1452), "AQAAAAIAAYagAAAAENnpc6LBBr4M/IMyqDzKbGWfT5KRAz62Gdj7kfz4SULhvvNl/qh/XhQBXoMSKQ0uVw==", "f108724e-6101-4914-848e-1c096c07fed0", new DateTime(2023, 7, 15, 14, 29, 0, 48, DateTimeKind.Local).AddTicks(1500) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Configurations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "86564ebb-8841-4b62-b224-8b4da46b6e46", new DateTime(2023, 7, 15, 12, 35, 54, 202, DateTimeKind.Local).AddTicks(8636), "AQAAAAIAAYagAAAAEMEfMUBhKn7ihCTw3P957quL6jP/a5RoDLWDJlv7nePRszLyv3FOhgf6i1H03/AAzw==", "20f0dd56-907f-4c5d-a094-b10e314217f8", new DateTime(2023, 7, 15, 12, 35, 54, 202, DateTimeKind.Local).AddTicks(8691) });
        }
    }
}
