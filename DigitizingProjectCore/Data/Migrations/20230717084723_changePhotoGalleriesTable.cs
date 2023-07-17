using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changePhotoGalleriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "PhotoGalleries");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "080eb7d5-5f6f-486e-a918-2fd9698417c3", new DateTime(2023, 7, 17, 11, 47, 23, 214, DateTimeKind.Local).AddTicks(6426), "AQAAAAIAAYagAAAAEHgYxx5LgH3BOvUJu9YLClPJuAqesGd71LD/xm00aYU4eta2eYTEbjNXGRL8TMQHNg==", "313253a7-f4f3-4f59-9058-1eb7552d2ff5", new DateTime(2023, 7, 17, 11, 47, 23, 214, DateTimeKind.Local).AddTicks(6510) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PhotoGalleries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "70ae2ee3-64fc-4dcf-875c-0dbc59c4b7f7", new DateTime(2023, 7, 17, 7, 44, 8, 458, DateTimeKind.Local).AddTicks(884), "AQAAAAIAAYagAAAAELQHll6/rxCdwYN4HNztG9T7NA3C3ahKVO3TukNrQQohKStvuveyfBncDY8epHjuWQ==", "0bf67e4c-5b32-450a-af5d-960de6b373d3", new DateTime(2023, 7, 17, 7, 44, 8, 458, DateTimeKind.Local).AddTicks(960) });
        }
    }
}
