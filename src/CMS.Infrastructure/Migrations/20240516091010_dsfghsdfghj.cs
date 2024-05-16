using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dsfghsdfghj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "Lessons");

            migrationBuilder.AddColumn<Guid>(
                name: "FromTimeId",
                table: "Lessons",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ToTimeId",
                table: "Lessons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomeTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Hour = table.Column<int>(type: "integer", nullable: false),
                    Minute = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomeTime", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_FromTimeId",
                table: "Lessons",
                column: "FromTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ToTimeId",
                table: "Lessons",
                column: "ToTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_CustomeTime_FromTimeId",
                table: "Lessons",
                column: "FromTimeId",
                principalTable: "CustomeTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_CustomeTime_ToTimeId",
                table: "Lessons",
                column: "ToTimeId",
                principalTable: "CustomeTime",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_CustomeTime_FromTimeId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_CustomeTime_ToTimeId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "CustomeTime");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_FromTimeId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ToTimeId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "FromTimeId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ToTimeId",
                table: "Lessons");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "FromTime",
                table: "Lessons",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "ToTime",
                table: "Lessons",
                type: "time without time zone",
                nullable: true);
        }
    }
}
