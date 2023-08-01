using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitizingProjectCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class createJobApplicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_DrivingLiscenceTypes_DrivingLiscenceTypeId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Jobs_JobId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_MaritalStatus_MaritalStatuId",
                table: "JobApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication");

            migrationBuilder.RenameTable(
                name: "JobApplication",
                newName: "jobApplications");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_MaritalStatuId",
                table: "jobApplications",
                newName: "IX_jobApplications_MaritalStatuId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_JobId",
                table: "jobApplications",
                newName: "IX_jobApplications_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_DrivingLiscenceTypeId",
                table: "jobApplications",
                newName: "IX_jobApplications_DrivingLiscenceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobApplications",
                table: "jobApplications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "b4999eab-94aa-4778-b8ce-d27108e7896a", new DateTime(2023, 7, 23, 11, 25, 27, 835, DateTimeKind.Local).AddTicks(8377), "AQAAAAIAAYagAAAAEKqekqI9fdazUpByR9lw5UUCjLA+A7pxYwAUOmILGT1+LJg/8ja7c8NZjsJYxADXqA==", "959b3fed-130f-4932-a7dc-2d393536ede4", new DateTime(2023, 7, 23, 11, 25, 27, 835, DateTimeKind.Local).AddTicks(8424) });

            migrationBuilder.AddForeignKey(
                name: "FK_jobApplications_DrivingLiscenceTypes_DrivingLiscenceTypeId",
                table: "jobApplications",
                column: "DrivingLiscenceTypeId",
                principalTable: "DrivingLiscenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobApplications_Jobs_JobId",
                table: "jobApplications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobApplications_MaritalStatus_MaritalStatuId",
                table: "jobApplications",
                column: "MaritalStatuId",
                principalTable: "MaritalStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobApplications_DrivingLiscenceTypes_DrivingLiscenceTypeId",
                table: "jobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_jobApplications_Jobs_JobId",
                table: "jobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_jobApplications_MaritalStatus_MaritalStatuId",
                table: "jobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobApplications",
                table: "jobApplications");

            migrationBuilder.RenameTable(
                name: "jobApplications",
                newName: "JobApplication");

            migrationBuilder.RenameIndex(
                name: "IX_jobApplications_MaritalStatuId",
                table: "JobApplication",
                newName: "IX_JobApplication_MaritalStatuId");

            migrationBuilder.RenameIndex(
                name: "IX_jobApplications_JobId",
                table: "JobApplication",
                newName: "IX_JobApplication_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_jobApplications_DrivingLiscenceTypeId",
                table: "JobApplication",
                newName: "IX_JobApplication_DrivingLiscenceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "Created_At", "PasswordHash", "SecurityStamp", "Updated_at" },
                values: new object[] { "8096d5d0-fca7-446f-b262-deebfb91cff9", new DateTime(2023, 7, 21, 22, 15, 54, 892, DateTimeKind.Local).AddTicks(4937), "AQAAAAIAAYagAAAAELL1yaNvOGhVTH1dUO1e/kf61RcPw8fsXG+yjPkPRiXBp0v6zXAEzNC5dtrR9JwOKg==", "0b008c4e-2fe6-4248-be03-996339be8b7b", new DateTime(2023, 7, 21, 22, 15, 54, 892, DateTimeKind.Local).AddTicks(5008) });

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_DrivingLiscenceTypes_DrivingLiscenceTypeId",
                table: "JobApplication",
                column: "DrivingLiscenceTypeId",
                principalTable: "DrivingLiscenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Jobs_JobId",
                table: "JobApplication",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_MaritalStatus_MaritalStatuId",
                table: "JobApplication",
                column: "MaritalStatuId",
                principalTable: "MaritalStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
