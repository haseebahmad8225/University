using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class onon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "ClassesSchedules",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<string>(
                name: "ClassStartTime",
                table: "ClassesSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "ClassEndTime",
                table: "ClassesSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "ClassesSchedules",
                newName: "teacherId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ClassStartTime",
                table: "ClassesSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ClassEndTime",
                table: "ClassesSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
