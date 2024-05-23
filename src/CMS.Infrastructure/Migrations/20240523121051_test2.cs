using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TZ",
                table: "Homeworks",
                newName: "Task");

            migrationBuilder.AddColumn<string>(
                name: "TaskPath",
                table: "Homeworks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskPath",
                table: "Homeworks");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "Homeworks",
                newName: "TZ");
        }
    }
}
