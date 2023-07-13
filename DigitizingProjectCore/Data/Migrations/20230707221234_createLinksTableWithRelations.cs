using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createLinksTableWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ShowInMenu = table.Column<bool>(type: "bit", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ParentIdForBar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLinks_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminLinks_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "6ce69326-d4cc-427e-843e-ec7d64d73d84", new DateTime(2023, 7, 8, 1, 12, 33, 951, DateTimeKind.Local).AddTicks(8465), "AQAAAAIAAYagAAAAEEttAWIz9VzhNGAvYYCUTLrHutqaJ5Pk+6mfMdgID8hr2MnOW4t1EgBGw17EgViiHQ==", "67105bee-d809-4bde-b70a-9b38f76f1155", new DateTime(2023, 7, 8, 1, 12, 33, 951, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.CreateIndex(
                name: "IX_AdminLinks_AdminId",
                table: "AdminLinks",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLinks_LinkId",
                table: "AdminLinks",
                column: "LinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLinks");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "eb902a0a-5162-44b8-96aa-ee37e753d99d", new DateTime(2023, 7, 7, 6, 49, 18, 415, DateTimeKind.Local).AddTicks(4651), "AQAAAAIAAYagAAAAEPMYopUHbE+opYTQWHvBr+oqrkbK61yPEL52sTDDVXkf1U5CfG+yZz0dkotGUOXH1Q==", "cb4b99da-25b9-46ba-abd5-767ab41b5037", new DateTime(2023, 7, 7, 6, 49, 18, 415, DateTimeKind.Local).AddTicks(4883) });
        }
    }
}
