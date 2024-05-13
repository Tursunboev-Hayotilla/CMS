using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Schools_SchoolId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Examines");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "Events",
                newName: "DateId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_SchoolId",
                table: "Events",
                newName: "IX_Events_DateId");

            migrationBuilder.AddColumn<Guid>(
                name: "DateId",
                table: "Examines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DateId",
                table: "Attendances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CustomeDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomeDate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examines_DateId",
                table: "Examines",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_DateId",
                table: "Attendances",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_CustomeDate_DateId",
                table: "Attendances",
                column: "DateId",
                principalTable: "CustomeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_CustomeDate_DateId",
                table: "Events",
                column: "DateId",
                principalTable: "CustomeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examines_CustomeDate_DateId",
                table: "Examines",
                column: "DateId",
                principalTable: "CustomeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_CustomeDate_DateId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_CustomeDate_DateId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Examines_CustomeDate_DateId",
                table: "Examines");

            migrationBuilder.DropTable(
                name: "CustomeDate");

            migrationBuilder.DropIndex(
                name: "IX_Examines_DateId",
                table: "Examines");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_DateId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Examines");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "DateId",
                table: "Events",
                newName: "SchoolId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_DateId",
                table: "Events",
                newName: "IX_Events_SchoolId");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Examines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Attendances",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Schools_SchoolId",
                table: "Events",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
