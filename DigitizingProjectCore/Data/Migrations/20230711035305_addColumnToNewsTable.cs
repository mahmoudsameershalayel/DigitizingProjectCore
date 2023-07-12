using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnToNewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoImageName",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "6f4567ab-1746-42a3-ab7f-93a117f02c57", new DateTime(2023, 7, 11, 6, 53, 4, 834, DateTimeKind.Local).AddTicks(2404), "AQAAAAIAAYagAAAAEOy/ikp55+NYkfZxlkGY9E2E8QmVABLZCuwmQ9G+o7W6aqunDKYDSBfFn33kq66C7g==", "b39a2160-1693-4e48-8a47-845fd6fe2ecf", new DateTime(2023, 7, 11, 6, 53, 4, 834, DateTimeKind.Local).AddTicks(2453) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoImageName",
                table: "News");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "566f5c78-3bb5-4e90-bb92-dea2d9454fca", new DateTime(2023, 7, 11, 6, 47, 28, 257, DateTimeKind.Local).AddTicks(4161), "AQAAAAIAAYagAAAAEMor4t7KMdGqO9uDIvKXuq5mlbngAL1QWGyiaWeFkbB0ah5XI6xKpvvPpk1Ilz2EEg==", "44421618-5d61-40e0-870c-987059ac306f", new DateTime(2023, 7, 11, 6, 47, 28, 257, DateTimeKind.Local).AddTicks(4216) });
        }
    }
}
