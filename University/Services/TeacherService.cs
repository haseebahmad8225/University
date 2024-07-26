using Application.DataTransferModels.ResponseModels;
using Dapper;
using Microsoft.Data.SqlClient;
using University.DataTransferModels;
using University.Interfaces;
using University.Model;

namespace University.Services
{
    public class TeacherService : ITeacher
    {
        private readonly IConfiguration _configuration;
        public TeacherService (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseVM> AssignTeacherStudent(TeacherStudentAsignVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"INSERT INTO AssignedDetails (TeacherId, StudentId) VALUES (@TeacherId, @StudentId)";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameters = new { TeacherId = model.TeacherId, StudentId = model.studentId };
            int result = await con.ExecuteAsync(query, parameters);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Insert Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Inserted";
            return response;
        }

        public async Task<ResponseVM> CreateTeacher(CreateTeacherVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            using var con = new SqlConnection(connectionstring);
            con.Open();
            string checkquery = $"Select * from TeacherDetails where Email = @Email";
            var checkParameter = new { Email = model.Email };
            IEnumerable<Teacher> teachers = await con.QueryAsync<Teacher>(checkquery, checkParameter);
            if (teachers.Count() != 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Email Already Exist";
                return response;
            }
            string query = $"Insert into TeacherDetails (FirstName , LastName, Subject , JoiningDate, DepartmentId, Phone, CNIC , Email, City , State, Country) Values (@FirstName , @LastName, @Subject , @JoiningDate, @DepartmentId, @Phone, @CNIC , @Email, @City , @State, @Country)";
            var parameter = new {FirstName = model.FirstName, LastName = model.LastName, Subject  = model.Subject, JoiningDate = model.JoiningDate, DepartmentId = model.DepartmentId ,Phone = model.Phone, CNIC = model.CNIC, Email = model.Email, City = model.City, State = model.State, Country = model.Country };
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Insert operation Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Inserted Successfully";
            return response;
 
        }
        public async Task<ResponseVM> DeleteTeacher(long TeacherId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Delete from TeacherDetails where TeacherId = @TeacherId";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new { TeacherId = TeacherId };
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Delete Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Deleted Successfully";
            return response;
        }
        public async Task<ResponseVM> GetTeachers()
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Select * from Teacherdetails";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            IEnumerable<Teacher> teachers = await con.QueryAsync<Teacher>(query);
            if (teachers is null)
            {
                response.responseCode = 404;
                response.errorMessage = "Student not found";
                return response;
            }
            response.responseCode = 200;
            response.data = teachers;
            return response;
        }

        public async Task<ResponseVM> UpdateTeacher(UpdateTeacherVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            using var con = new SqlConnection( connectionstring);
            con.Open();
            string checkquery = $"Select * from TeacherDetails where Email = @Email";
            var checkParameter = new {Email = model.Email };
            IEnumerable<Teacher> teachers = await con.QueryAsync<Teacher>(checkquery, checkParameter);
            if (teachers.Count() != 0) 
            {
                response.responseCode = 400;
                response.errorMessage = "Email Already Exist";
                return response;
            }
            string query = $"Update TeacherDetails SET FirstName = @FirstName, LastName = @LastName, Subject = @Subject, JoiningDate = @JoiningDate, DepartmentId = @DepartmentId, Phone = @Phone, CNIC = @CNIC, Email = @Email, City = @City, State = @State, Country = @Country Where TeacherId = @TeacherId ";
            var parameter = new {FirstName = model.FirstName, LastName = model.LastName, Subject = model.Subject, JoiningDate = model.JoiningDate, DepartmentId = model.DepartmentId, Phone = model.Phone, CNIC = model.CNIC, Email = model.Email, City = model.City, State = model.State, Country = model.Country, TeacherId = model.TeacherId};
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0) 
            {
                response.responseCode = 400;
                response.errorMessage = "Update Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Update Complete";
            return response;
        }
    }
}
