using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createHomePageBannersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePageBanners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    SortId = table.Column<int>(type: "int", nullable: true),
                    ShowText = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageBanners", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "9835c06a-e462-4850-b4c2-8da83b55e5c3", new DateTime(2023, 7, 16, 7, 45, 28, 90, DateTimeKind.Local).AddTicks(2351), "AQAAAAIAAYagAAAAEDM0V4QvWFtfNlrUGYPjfDX5nK7XopQdBTpX69RL9ViIi110cF24t2LST7j6vbb9iA==", "9719eed3-e54a-4d82-9603-cdcbe8cf13b0", new DateTime(2023, 7, 16, 7, 45, 28, 90, DateTimeKind.Local).AddTicks(2414) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePageBanners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "11da41ff-62d0-46a7-90fa-a9da94c68855", new DateTime(2023, 7, 15, 16, 35, 17, 68, DateTimeKind.Local).AddTicks(159), "AQAAAAIAAYagAAAAEDG52iuUajZ/qo5aruBOONgUNuZlfPP/ry8tlU7tQNc33BwXP+eCo9ZP83MqrB/2wA==", "7554f0fc-9dfd-41df-8e04-0c6b5139c282", new DateTime(2023, 7, 15, 16, 35, 17, 68, DateTimeKind.Local).AddTicks(217) });
        }
    }
}
