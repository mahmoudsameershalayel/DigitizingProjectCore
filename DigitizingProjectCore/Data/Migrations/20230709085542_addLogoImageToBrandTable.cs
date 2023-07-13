using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class addLogoImageToBrandTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoImageName",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "2b09a222-45e9-4cfd-a7e8-1a932de759fe", new DateTime(2023, 7, 9, 11, 55, 42, 535, DateTimeKind.Local).AddTicks(1910), "AQAAAAIAAYagAAAAEL8MjqrjTO3FJskRjLpA8QUrrKj3cf44g8c3gsqdd2/3Lrnv29W57uBTnlRSe5QkTw==", "ff2ed226-6761-4176-b79f-311ab3a75c43", new DateTime(2023, 7, 9, 11, 55, 42, 535, DateTimeKind.Local).AddTicks(1963) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoImageName",
                table: "Brands");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "eaf9c2bb-6d6a-4e0d-a8b3-a78d8accd223", new DateTime(2023, 7, 9, 6, 0, 14, 329, DateTimeKind.Local).AddTicks(6131), "AQAAAAIAAYagAAAAEPbyBGRaF+GiVpep+DT0shi5+rLLOC3PI0F9xDqYRhZ/1E5Frp2NIZYCHAIJ6QO5mQ==", "1b8c97ac-96a4-459b-8739-6893e18fbf54", new DateTime(2023, 7, 9, 6, 0, 14, 329, DateTimeKind.Local).AddTicks(6183) });
        }
    }
}
