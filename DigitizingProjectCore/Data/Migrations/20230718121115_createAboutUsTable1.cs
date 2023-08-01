using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createAboutUsTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailsAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhyUsAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhyUsEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprouchAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprouchEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowServices = table.Column<bool>(type: "bit", nullable: false),
                    ShowPartners = table.Column<bool>(type: "bit", nullable: false),
                    TitlesAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitlesEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "592a2144-569b-4949-8d2a-4cedfd564a92", new DateTime(2023, 7, 18, 15, 11, 15, 593, DateTimeKind.Local).AddTicks(5667), "AQAAAAIAAYagAAAAENDdvOBDiVt6QuWmyTfnuNn5IH71G4MeVkK4hrOkn017hCz5AN2BlP7qOUVrEAN5pg==", "56026f7b-a69f-453b-a9db-0e0fff65c78c", new DateTime(2023, 7, 18, 15, 11, 15, 593, DateTimeKind.Local).AddTicks(5727) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "725d7e86-18f4-4451-b2d5-f3d12a1a7b69", new DateTime(2023, 7, 18, 12, 3, 59, 34, DateTimeKind.Local).AddTicks(3604), "AQAAAAIAAYagAAAAEJCwSlssO6qaePo156YKcf+8OTPqM54Ip3iA3iU2+YDc9EF6mUzK9tnDZH/KTBiS3A==", "6a3426e6-eeb1-4fa2-ab2a-d9d65060d74d", new DateTime(2023, 7, 18, 12, 3, 59, 34, DateTimeKind.Local).AddTicks(3658) });
        }
    }
}
