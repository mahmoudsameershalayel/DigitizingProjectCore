using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class auth3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a00de05-ab2c-4692-82b2-d33f0f50eb7e", "f1446937-109c-4e1a-97ce-0560442484f5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a00de05-ab2c-4692-82b2-d33f0f50eb7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a00de05-ab2c-4692-82b2-d33f0f50eb7e", "9a00de05-ab2c-4692-82b2-d33f0f50eb7e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_At", "Created_By", "Email", "EmailConfirmed", "FullName", "Gender", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[] { "f1446937-109c-4e1a-97ce-0560442484f5", 0, "0bd0f2ce-cd5d-4ee2-bb40-9391b3fce9e2", new DateTime(2023, 8, 4, 15, 44, 49, 16, DateTimeKind.Local).AddTicks(6072), null, "Admin@admin.com", false, "System Administrator", 0, true, false, false, null, "ADMIN@ADMIN.COM", null, "AQAAAAIAAYagAAAAEKJz19xkxIvzmkvGBm/qmg9T+TdTFn1hHjqT6lBE/oQT+sdLY/6Cn0qKYhq5hHZNdg==", "97259000000", null, false, "f3fd7733-90a8-44af-99e5-c7a41a529c3b", false, new DateTime(2023, 8, 4, 15, 44, 49, 16, DateTimeKind.Local).AddTicks(6127), null, "System_Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9a00de05-ab2c-4692-82b2-d33f0f50eb7e", "f1446937-109c-4e1a-97ce-0560442484f5" });
        }
    }
}
