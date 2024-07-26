using University.Interfaces;
using University.Services;

namespace University.InjectServices
{
    public static class CustomServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartment, DepartmentService>();
            services.AddScoped<IStudent, StudentService>();
            services.AddScoped<ITeacher, TeacherService>();
            services.AddScoped<IUniversity, UniversityServices>();
            services.AddScoped<IClassesSchedule, ClassScheduleServices>();
            services.AddScoped<ITeacherSchedule, TeacherScheduleServices>();
        }
    }
}
