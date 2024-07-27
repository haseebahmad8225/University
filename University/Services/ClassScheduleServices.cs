using Application.DataTransferModels.ResponseModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using University.DataTransferModels;
using University.Interfaces;
using University.Migrations;
using University.Model;

namespace University.Services
{
    public class ClassScheduleServices : IClassesSchedule
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public ClassScheduleServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("UniversityContext"));
        }
        public async Task<ResponseVM> CreateClassSchedule(CreateClassVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Insert Into ClassesSchedules(DepartmentId, TeacherId, Subject, ClassStartTime, ClassEndTime) VALUES (@DepartmentId, @TeacherId, @Subject, @ClassStartTime, @ClassEndTime)";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new {DepartmentId = model.DepartmentId, TeacherId = model.teacherId, Subject = model.Subject, ClassStartTime = model.ClassStartTime, ClassEndTime = model.ClassEndTime};
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Insert Operation Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Inserted Successfully";
            return response;    
        }

        public async Task<ResponseVM> DeleteClassSchedule(long ClassId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Delete from ClassesSchedules Where ClassId = @ClassId";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new { ClassId = ClassId };
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Delete Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Data Deleted";
            return response;
        }

        public async Task<ResponseVM> GetClassSchedule()
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Select * from Classesschedules";
            using var con = new SqlConnection( connectionstring);
            con.Open();
            IEnumerable<ClassesSchedules> schedules = await con.QueryAsync<ClassesSchedules>(query);
            if (schedules == null)
            {
                response.responseCode = 404;
                response.errorMessage = "Schedule Not Found";
                return response;
            }
            response.responseCode=200;
            response.data = schedules;
            return response;
        }

        public async Task<ResponseVM> GetIndividualSchedule(long ClassId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            var parameters = new DynamicParameters();
            parameters.Add("@ClassId", ClassId);
            var s = await _connection.QueryAsync<dynamic>("sp_GetClassSchedule", parameters, commandType: CommandType.StoredProcedure);

            response.responseCode = 200;
            response.data = s;
            return response;
        }

        public async Task<ResponseVM> GetIndividualTeacher(long TeacherId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            var parameters = new DynamicParameters();
            parameters.Add("@TeacherId", TeacherId );
            var s = await _connection.QueryAsync<dynamic>("sp_ClassIndividualTeacher", parameters, commandType: CommandType.StoredProcedure);

            response.responseCode = 200;
            response.data = s;
            return response;
        }

        public async Task<ResponseVM> GetTeacherDepartment()
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            var s = await _connection.QueryAsync<dynamic>("sp_ClassTeacherDepartment", commandType: CommandType.StoredProcedure);
            response.responseCode = 200;
            response.data = s;
            return response;
        }

        public async Task<ResponseVM> UpdateClassSchedule(UpdateClassVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Update ClassesSchedules Set DepartmentId = @DepartmentId, TeacherId = @TeacherId, Subject = @Subject,ClassStartTime = @ClassStartTime, ClassEndTime = @ClassEndTime WHERE ClassId = @ClassId";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new { DepartmentId = model.DepartmentId, TeacherId = model.teacherId, Subject = model.Subject, ClassStartTime = model.ClassStartTime, ClassEndTime = model.ClassEndTime, ClassId = model.ClassId };
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Update Unsuccessful";
                return response;
            }
            response.responseCode=200;
            response.responseMessage = "Updated Successfully";
            return response;
        }
    }
}
