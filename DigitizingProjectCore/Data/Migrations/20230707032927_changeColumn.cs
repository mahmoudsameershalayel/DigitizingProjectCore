using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "927fa633-24aa-4a94-9622-7e1013027e87", new DateTime(2023, 7, 7, 6, 29, 26, 988, DateTimeKind.Local).AddTicks(9316), "AQAAAAIAAYagAAAAECn/9QgRNh1xjjW0rmn5BLxK+xsRCXb5rJRUWRgwf+DFefkFfOYyIAZmJYaG4pLnjA==", "b2c29b63-ee5e-47b3-a800-4f60a9c835d3", new DateTime(2023, 7, 7, 6, 29, 26, 988, DateTimeKind.Local).AddTicks(9373) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "ProductCategoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "f5270ca5-3dc3-4de5-a31e-4449e420416e", new DateTime(2023, 7, 5, 21, 33, 29, 262, DateTimeKind.Local).AddTicks(4372), "AQAAAAIAAYagAAAAEAhjSvf+Vyh/fBtwrAeedqr8V8NO7S4MKeu8qs1qJl5PbAvjkf4HGvJjyBJsmTaGgw==", "d6524963-634d-40dc-9237-27b4e34d95ef", new DateTime(2023, 7, 5, 21, 33, 29, 262, DateTimeKind.Local).AddTicks(4434) });
        }
    }
}
