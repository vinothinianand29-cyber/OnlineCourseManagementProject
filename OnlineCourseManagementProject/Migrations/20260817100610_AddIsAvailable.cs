using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourseManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "CourseDatas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "CourseDatas");
        }
    }
}
