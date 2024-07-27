using Microsoft.EntityFrameworkCore;
using System;
using University.Model;
namespace UniversityService.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext (DbContextOptions<UniversityContext> options)
          : base(options)
        {

        }
        public DbSet<UniversityDetails> UniversityDetails { get; set; }
        public DbSet<Student> StudentDetails { get; set; }
        public DbSet<Teacher> TeacherDetails { get; set; }
        public DbSet<Department> DepartmentDetails { get; set; }
        public DbSet<TeacherRoles> TeacherRoleDetails { get; set; }    
        public DbSet<TeacherStudentAsign> AssignedDetails { get; set; }
        public DbSet<ClassesSchedules> ClassesSchedules { get; set; }
        public DbSet<TeacherSchedule> TeacherClassesSchedule { get; set; }
    }
}