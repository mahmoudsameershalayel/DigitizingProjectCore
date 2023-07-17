using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createPhotoGalleriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortId = table.Column<int>(type: "int", nullable: false),
                    SummaryEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoGalleries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "70ae2ee3-64fc-4dcf-875c-0dbc59c4b7f7", new DateTime(2023, 7, 17, 7, 44, 8, 458, DateTimeKind.Local).AddTicks(884), "AQAAAAIAAYagAAAAELQHll6/rxCdwYN4HNztG9T7NA3C3ahKVO3TukNrQQohKStvuveyfBncDY8epHjuWQ==", "0bf67e4c-5b32-450a-af5d-960de6b373d3", new DateTime(2023, 7, 17, 7, 44, 8, 458, DateTimeKind.Local).AddTicks(960) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoGalleries");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "5f6ff2f2-63b8-44a6-93fd-2f41aeb0c7d8", new DateTime(2023, 7, 16, 7, 52, 31, 152, DateTimeKind.Local).AddTicks(7620), "AQAAAAIAAYagAAAAENxIydgMXLgRoM1jehhU2VjCo9HSGl6C9OpmsnnwTokenefRSlaRM6cCCHeA9tGtWA==", "c22d0091-1152-4603-ac21-3efff0b6dc8d", new DateTime(2023, 7, 16, 7, 52, 31, 152, DateTimeKind.Local).AddTicks(8151) });
        }
    }
}
