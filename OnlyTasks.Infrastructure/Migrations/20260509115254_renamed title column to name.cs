using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyTasks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Renamedtitlecolumntoname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tasks",
                newName: "Title");
        }
    }
}
