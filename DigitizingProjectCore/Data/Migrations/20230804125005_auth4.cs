using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class auth4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a00de05-ab2c-4692-82b2-d33f0f50eb7e", "9a00de05-ab2c-4692-82b2-d33f0f50eb7e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_At", "Created_By", "Email", "EmailConfirmed", "FullName", "Gender", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[] { "f1446937-109c-4e1a-97ce-0560442484f5", 0, "751e6d51-df5b-4240-afac-159944b90bb6", new DateTime(2023, 8, 4, 15, 50, 5, 147, DateTimeKind.Local).AddTicks(6301), null, "Administrator@admin.com", false, "System Administrator", 0, true, false, false, null, "ADMINISTRATOR@ADMIN.COM", null, "AQAAAAIAAYagAAAAEMhb9mMK7O/WpqwK1mgSf59niETRtDsX2ruMpnWeya/Ms9msy4B9ZPAuXsHhFYtgMw==", "97259000000", null, false, "c2c6c75a-80b1-46c3-8e40-e15442edbf9b", false, new DateTime(2023, 8, 4, 15, 50, 5, 147, DateTimeKind.Local).AddTicks(6354), null, "System_Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9a00de05-ab2c-4692-82b2-d33f0f50eb7e", "f1446937-109c-4e1a-97ce-0560442484f5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
