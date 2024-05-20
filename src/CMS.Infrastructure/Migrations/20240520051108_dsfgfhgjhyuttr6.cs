using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dsfgfhgjhyuttr6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coin",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Homeworks",
                newName: "TZ");

            migrationBuilder.AddColumn<Guid>(
                name: "BirthDateId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DateOfBirthId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Employee_BirthDateId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExamAppraciates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<string>(type: "text", nullable: false),
                    Coins = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAppraciates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamAppraciates_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAppraciates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    studentId = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonCoin = table.Column<byte>(type: "smallint", nullable: true),
                    HomeworkCoin = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAppraciates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BirthDateId",
                table: "AspNetUsers",
                column: "BirthDateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DateOfBirthId",
                table: "AspNetUsers",
                column: "DateOfBirthId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Employee_BirthDateId",
                table: "AspNetUsers",
                column: "Employee_BirthDateId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAppraciates_StudentId",
                table: "ExamAppraciates",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomeDate_BirthDateId",
                table: "AspNetUsers",
                column: "BirthDateId",
                principalTable: "CustomeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomeDate_DateOfBirthId",
                table: "AspNetUsers",
                column: "DateOfBirthId",
                principalTable: "CustomeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomeDate_Employee_BirthDateId",
                table: "AspNetUsers",
                column: "Employee_BirthDateId",
                principalTable: "CustomeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomeDate_BirthDateId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomeDate_DateOfBirthId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomeDate_Employee_BirthDateId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExamAppraciates");

            migrationBuilder.DropTable(
                name: "StudentAppraciates");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BirthDateId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DateOfBirthId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Employee_BirthDateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirthId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Employee_BirthDateId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TZ",
                table: "Homeworks",
                newName: "Result");

            migrationBuilder.AddColumn<int>(
                name: "Coin",
                table: "Homeworks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndDate",
                table: "Homeworks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                table: "Homeworks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
