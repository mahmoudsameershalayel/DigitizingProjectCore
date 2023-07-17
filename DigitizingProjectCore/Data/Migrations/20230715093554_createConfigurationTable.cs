using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createConfigurationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaceBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instegram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductsSloganEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductsSloganAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingSloganEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingSloganAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsSloganEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsSloganAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactUsSloganEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactUsSloganAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "86564ebb-8841-4b62-b224-8b4da46b6e46", new DateTime(2023, 7, 15, 12, 35, 54, 202, DateTimeKind.Local).AddTicks(8636), "AQAAAAIAAYagAAAAEMEfMUBhKn7ihCTw3P957quL6jP/a5RoDLWDJlv7nePRszLyv3FOhgf6i1H03/AAzw==", "20f0dd56-907f-4c5d-a094-b10e314217f8", new DateTime(2023, 7, 15, 12, 35, 54, 202, DateTimeKind.Local).AddTicks(8691) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "5995385c-c1d9-49cf-97a5-aceac5a5ebae", new DateTime(2023, 7, 11, 7, 36, 15, 279, DateTimeKind.Local).AddTicks(9635), "AQAAAAIAAYagAAAAEBwUnNH49xYPwQOhUdm6mkYNSy/f27zAmpk7ib+DqS7KUVlNRkRK2DEf6bX70H6OTA==", "6095bb55-ca0a-480e-b001-9f8ce10930d1", new DateTime(2023, 7, 11, 7, 36, 15, 279, DateTimeKind.Local).AddTicks(9699) });
        }
    }
}
