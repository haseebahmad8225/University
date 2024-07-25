using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassesSchedules",
                columns: table => new
                {
                    ClassId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    teacherId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    ClassStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClassEndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesSchedules", x => x.ClassId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassesSchedules");
        }
    }
}
