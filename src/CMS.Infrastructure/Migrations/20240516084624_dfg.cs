using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Classes_ClassId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_StudentAttendance_StudentAttendanceId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_TeacherId1",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_AspNetUsers_StudentId",
                table: "StudentAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_Lessons_LessonId",
                table: "StudentAttendance");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TeacherId1",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_ClassId",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "StudentAttendance",
                newName: "StudentAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_StudentId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_LessonId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_LessonId");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Classes",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherId",
                table: "Classes",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_StudentAttendances_StudentAttendanceId",
                table: "Attendances",
                column: "StudentAttendanceId",
                principalTable: "StudentAttendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_TeacherId",
                table: "Classes",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_AspNetUsers_StudentId",
                table: "StudentAttendances",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Lessons_LessonId",
                table: "StudentAttendances",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_StudentAttendances_StudentAttendanceId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_TeacherId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_AspNetUsers_StudentId",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Lessons_LessonId",
                table: "StudentAttendances");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TeacherId",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances");

            migrationBuilder.RenameTable(
                name: "StudentAttendances",
                newName: "StudentAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_LessonId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_LessonId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Classes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId1",
                table: "Classes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Attendances",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherId1",
                table: "Classes",
                column: "TeacherId1");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ClassId",
                table: "Attendances",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Classes_ClassId",
                table: "Attendances",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_StudentAttendance_StudentAttendanceId",
                table: "Attendances",
                column: "StudentAttendanceId",
                principalTable: "StudentAttendance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_TeacherId1",
                table: "Classes",
                column: "TeacherId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_AspNetUsers_StudentId",
                table: "StudentAttendance",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_Lessons_LessonId",
                table: "StudentAttendance",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
