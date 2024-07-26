using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class teww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shift",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "Timing",
                table: "TeacherDetails");

            migrationBuilder.AddColumn<string>(
                name: "Shift",
                table: "ClassesSchedules",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shift",
                table: "ClassesSchedules");

            migrationBuilder.AddColumn<string>(
                name: "Shift",
                table: "TeacherDetails",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Timing",
                table: "TeacherDetails",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
