using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class Teachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDetails_DepartmentDetails_DepartmentId",
                table: "TeacherDetails");

            migrationBuilder.DropIndex(
                name: "IX_TeacherDetails_DepartmentId",
                table: "TeacherDetails");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_DepartmentId",
                table: "StudentDetails",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDetails_DepartmentDetails_DepartmentId",
                table: "StudentDetails",
                column: "DepartmentId",
                principalTable: "DepartmentDetails",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_DepartmentDetails_DepartmentId",
                table: "StudentDetails");

            migrationBuilder.DropIndex(
                name: "IX_StudentDetails_DepartmentId",
                table: "StudentDetails");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDetails_DepartmentId",
                table: "TeacherDetails",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDetails_DepartmentDetails_DepartmentId",
                table: "TeacherDetails",
                column: "DepartmentId",
                principalTable: "DepartmentDetails",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
