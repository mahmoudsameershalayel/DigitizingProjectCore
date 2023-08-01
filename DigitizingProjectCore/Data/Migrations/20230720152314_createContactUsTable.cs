using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createContactUsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "5e9adb43-9a24-4457-8407-4a267eaabbd8", new DateTime(2023, 7, 20, 18, 23, 14, 216, DateTimeKind.Local).AddTicks(3843), "AQAAAAIAAYagAAAAEIopINfdHPGqvMFwF+o5kXAbJ9I5vSxmqYe0aGcB7DGcEfJfSG1qoVqVogm3stGP3Q==", "e91d1d85-712c-414c-b046-a36bdd931493", new DateTime(2023, 7, 20, 18, 23, 14, 216, DateTimeKind.Local).AddTicks(3905) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "592a2144-569b-4949-8d2a-4cedfd564a92", new DateTime(2023, 7, 18, 15, 11, 15, 593, DateTimeKind.Local).AddTicks(5667), "AQAAAAIAAYagAAAAENDdvOBDiVt6QuWmyTfnuNn5IH71G4MeVkK4hrOkn017hCz5AN2BlP7qOUVrEAN5pg==", "56026f7b-a69f-453b-a9db-0e0fff65c78c", new DateTime(2023, 7, 18, 15, 11, 15, 593, DateTimeKind.Local).AddTicks(5727) });
        }
    }
}
