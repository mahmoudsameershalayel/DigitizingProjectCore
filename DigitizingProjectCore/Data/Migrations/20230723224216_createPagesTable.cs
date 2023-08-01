using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createPagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "231e387b-ae08-41bd-98b5-afa8450fc130", new DateTime(2023, 7, 24, 1, 42, 16, 378, DateTimeKind.Local).AddTicks(9282), "AQAAAAIAAYagAAAAEN7bBBjK3Kx4PBGGjBHmf4weIPMu9Yh0FyHGY0slHUUxOm1pzmzZFKPanfnfMHMdIg==", "7e2195ab-59ee-4623-9213-b63587230c87", new DateTime(2023, 7, 24, 1, 42, 16, 378, DateTimeKind.Local).AddTicks(9340) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "729c3f4e-978d-4f4f-96ef-b51cf599f3d8", new DateTime(2023, 7, 24, 0, 41, 12, 608, DateTimeKind.Local).AddTicks(78), "AQAAAAIAAYagAAAAEDhKQnuAr7NCNW0hAaAlRLxleIHKhRQKGE3LwDlaEYkOoc7W16Ap0C0m3Mc4euqCBg==", "68c61326-9a84-485b-a1ce-eb617118c2a7", new DateTime(2023, 7, 24, 0, 41, 12, 608, DateTimeKind.Local).AddTicks(128) });
        }
    }
}
