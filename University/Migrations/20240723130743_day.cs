using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class day : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_DepartmentDetails_DepartmentId",
                table: "StudentDetails");

            migrationBuilder.DropIndex(
                name: "IX_StudentDetails_DepartmentId",
                table: "StudentDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
