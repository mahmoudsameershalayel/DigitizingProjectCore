using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createSettingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "6bd86702-17bc-4f82-9aaf-d6c370814a1c", new DateTime(2023, 7, 8, 15, 19, 30, 535, DateTimeKind.Local).AddTicks(1462), "AQAAAAIAAYagAAAAEPl2CDCoJFpfme8u9rcYhA+Ef1s2Gf8ZjveFrD6POlSAsFzucmGbXDmrWCYEMUb4AQ==", "b5cedce2-e2ae-4074-9bec-04b14b08502f", new DateTime(2023, 7, 8, 15, 19, 30, 535, DateTimeKind.Local).AddTicks(1537) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "e93620ac-24e4-4392-9ba2-3a3830ac03fb", new DateTime(2023, 7, 8, 14, 39, 2, 887, DateTimeKind.Local).AddTicks(1847), "AQAAAAIAAYagAAAAEIsBRi4efa4HjEdFM9k8Zz15TQ43aV1TE/vwkzDEkgiwnfNrkHJ2rjqxLuApv4887w==", "50414b01-1bb6-44e2-a637-7701b87a29db", new DateTime(2023, 7, 8, 14, 39, 2, 887, DateTimeKind.Local).AddTicks(1901) });
        }
    }
}
