using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class initMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityDetails",
                columns: table => new
                {
                    UniversityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    EstablishedYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityDetails", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDetails",
                columns: table => new
                {
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    UniversityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDetails", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_DepartmentDetails_UniversityDetails_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "UniversityDetails",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDetails",
                columns: table => new
                {
                    TeacherId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Subject = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    JoiningDate = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    CNIC = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    State = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDetails", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_TeacherDetails_DepartmentDetails_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentDetails",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    StudentName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    FatherName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CNIC = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DOB = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Religion = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    AdmissionDate = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Semester = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    State = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentDetails_TeacherDetails_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeacherDetails",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDetails_UniversityId",
                table: "DepartmentDetails",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_TeacherId",
                table: "StudentDetails",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDetails_DepartmentId",
                table: "TeacherDetails",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "TeacherDetails");

            migrationBuilder.DropTable(
                name: "DepartmentDetails");

            migrationBuilder.DropTable(
                name: "UniversityDetails");
        }
    }
}
