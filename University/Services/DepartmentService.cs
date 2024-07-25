using Application.DataTransferModels.ResponseModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using University.DataTransferModels;
using University.Interfaces;
using University.Model;

namespace University.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public DepartmentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("UniversityContext"));
        }

        public async Task<ResponseVM> AssignHeadRole(AssignHeadRoleVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Insert Into TeacherRoleDetails (TeacherId, DepartmentId, Role) Values (@TeacherId, @DepartmentId, @Role)";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameters = new { TeacherId = model.TeacherId, DepartmentId = model.DepartmentId, Role = model.Role };
            int result = await con.ExecuteAsync(query, parameters);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Insert Operation Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Inserted";
            return response;
        }

        public async Task<ResponseVM> CreateDepartment(CreateDepartmentVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionString = _configuration.GetConnectionString("UniversityContext");
            string query = $"INSERT INTO DepartmentDetails(DepartmentName, Description, UniversityId) Values(@Name, @Description, @UniversityId)";
            using var con = new SqlConnection(connectionString);        
            con.Open();
            var parameters = new {Name = model.DepartmentName, Description = model.Description, UniversityId = model.UniversityId};
            int result = await con.ExecuteAsync(query,parameters);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Insert operation unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Insert operation successful";
            return response;
        }

        public async Task<ResponseVM> DeleteDepartment(long Departmentid)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Delete from DepartmentDetails where DepartmentId = @DepartmentId";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new {Departmentid = Departmentid};
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Delete request unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Delete operation successful";
            return response;
        }

        public async Task<ResponseVM> GetAllStudents(long DepartmentId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Select * from StudentDetails where DepartmentId = @DepartmentId";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new { DepartmentId = DepartmentId };
            IEnumerable<Student> students = await con.QueryAsync<Student>(query, parameter);
            if (students == null)
            {
                response.responseCode = 404;
                response.errorMessage = "Student not Found";
                return response;
            }
            response.responseCode= 200;
            response.data = students;
            return response;
        }

        public async Task<ResponseVM> GetAllTeachers(long DepartmentId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("universityContext");
            string query = $"Select * from Teacherdetails where DepartmentId = @DepartmentId ";
            using var con = new SqlConnection( connectionstring);
            con.Open();
            var parameter = new { DepartmentId = DepartmentId };
            IEnumerable<Teacher> teachers = await con.QueryAsync<Teacher>(query, parameter);
            if (teachers == null)
            {
                response.responseCode = 404;
                response.errorMessage = "Teachers Not Found";
                return response;
            }
            response.responseCode= 200;
            response.data = teachers;
            return response;
        }

        public async Task<ResponseVM> GetDepartments()
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Select * from DepartmentDetails ";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            IEnumerable<Department> departments = await con.QueryAsync<Department>(query);
            if (departments is null)
            {
                response.responseCode = 404;
                response.errorMessage = "Departments not found";
                return response;
            }
            response.responseCode = 200;
            response.data = departments;
            return response;
        }

        public async Task<ResponseVM> GetTeachersCount()
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
          
            var s = await _connection.QueryAsync<dynamic>("sp_DepartmentsTeacher", commandType: CommandType.StoredProcedure);

            response.responseCode = 200;
            response.data = s;
            return response; ;
        }

        public async Task<ResponseVM> UpdateDepartment(UpdateDepartmentVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"update DepartmentDetails set DepartmentName = @Name, Description = @Description, UniversityId = @UniversityId where DepartmentId = @DepartmentId " ;
            using var con = new SqlConnection( connectionstring);
            con.Open();
            var parameter = new { Name = model.DepartmentName, Description = model.Description , UniversityId = model.UniversityId, DepartmentId = model.DepartmentId};
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.responseMessage = "Update unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Updated Successfully";
            return response;
        }
    }
}
