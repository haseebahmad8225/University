using Application.DataTransferModels.ResponseModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using University.DataTransferModels;
using University.Interfaces;
using University.Model;

namespace University.Services
{
    public class TeacherScheduleServices : ITeacherSchedule
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        public TeacherScheduleServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("UniversityContext"));
        }
        public async Task<ResponseVM> CreateTeacherSchedule(CreateTeacherScheduleVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"INSERT INTO TeacherClassesSchedule (TeacherId, DepartmentId, Subject, Shift, Timing) VALUES (@TeacherId, @DepartmentId, @Subject, @shift, @Timing)";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameters = new {TeacherId = model.TeacherId, DepartmentId = model.DepartmentId, Subject = model.Subject, Shift = model.Shift, Timing =model.Timing};
            int result = await con.ExecuteAsync(query, parameters);
            if (result == 0)
            { 
                response.responseCode = 400;
                response.errorMessage = "Insert Operation Failed";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Inserted Successfully";
            return response;
        }

        public async Task<ResponseVM> DeleteTeacherSchedule(long Id)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"DELETE FROM TeacherClassesSchedule WHERE Id = @Id";
            using var con = new SqlConnection( connectionstring);
            con.Open();
            var parameters = new { Id = Id, };
            int result = await con.ExecuteAsync(query, parameters);
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

        public async Task<ResponseVM> GetAllSchedule(long TeacherId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            var parameters = new DynamicParameters();
            parameters.Add("@TeacherId", TeacherId);
            var s = await _connection.QueryAsync<dynamic>("sp_AllSchedule",parameters, commandType: CommandType.StoredProcedure);
            response.responseCode = 200;
            response.data = s;
            return response;
        }

        public async Task<ResponseVM> GetTeacherSchedule()
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"SELECT * FROM TeacherClassesSchedule ";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            IEnumerable<TeacherSchedule> schedule = await con.QueryAsync<TeacherSchedule>(query);
            if (schedule == null)
            {
                response.responseCode = 404;
                response.errorMessage = "Data Not Found";
                return response;
            }
            response.responseCode = 200;
            response.data = schedule;
            return response;
        }

        public async Task<ResponseVM> UpdateTeacherSchedule(UpdateTeacherScheduleVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"UPDATE TeacherClassesSchedule SET TeacherId = @TeacherId, DepartmentId = @DepartmentId, Subject = @Subject, Shift = @Shift, Timing = @Timing WHERE Id = @Id";
            using var con = new SqlConnection( connectionstring);
            con.Open();
            var parameters = new { TeacherId = model.TeacherId, DepartmentId = model.DepartmentId, Subject = model.Subject, Shift = model.Shift, Timing = model.Timing, Id = model.Id};
            int result = await con.ExecuteAsync(query, parameters);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Update Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Updated Successfully";
            return response;
        }
    }
}
