using Application.DataTransferModels.ResponseModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;
using University.DataTransferModels;
using University.Interfaces;
using University.Model;
using UniversityService.Data;

namespace University.Services
{
    public class StudentService : IStudent
    {
        private readonly IConfiguration _configuration;
        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseVM> CreateStudent(CreateStudentVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionString = _configuration.GetConnectionString("UniversityContext");
            string query = $"INSERT into StudentDetails( TeacherId, StudentName, FatherName ,Age, CNIC, DOB, Religion, AdmissionDate, DepartmentId, Semester, Email, Phone, City, State, Country)  Values (@TeacherId, @StudentName, @FatherName, @Age, @CNIC, @DOB, @Religion, @AdmissionDate, @DepartmentId, @Semester, @Email, @Phone, @City, @State, @Country)";
            using var con = new SqlConnection(connectionString) ;
            con.Open();
            var parameter = new {TeacherId = model.TeacherId, StudentName = model.StudentName , FatherName = model.FatherName , Age = model.Age , CNIC = model.CNIC , DOB = model.DOB , Religion = model.Religion , AdmissionDate = model.AdmissionDate , DepartmentId =model.DepartmentId, Semester = model.Semester , Email = model.Email , Phone = model.Phone , City = model.City , State = model.State , Country = model.Country};
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Insert operation unsuccesful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Insert operation Successful";
            return response;

        }

        public async Task<ResponseVM> DeleteStudent(long Studentid)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $" Delete from StudentDetails where StudentId = @StudentId";
            using var con = new SqlConnection( connectionstring) ;
            con.Open();
            var parameter = new { StudentId = Studentid };
            int result = await con.ExecuteAsync(query , parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Delete unsuccessful";
                return response;  
            }
            response.responseCode = 200;
            response.responseMessage = "Deleted Successfully";
            return response;
        }

        public async Task<ResponseVM> GetStudents()
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Select * from StudentDetails";
            using var con = new SqlConnection(connectionstring) ;
            con.Open();
            IEnumerable<Student> students = await con.QueryAsync<Student>(query);
            if (students is null)
            {
                response.responseCode = 404;
                response.errorMessage = "Student not found";
                return response;
            }
            response.responseCode = 200;
            response.data = students;
            return response;
        }

        public async Task<ResponseVM> UpdateStatus(UpdateStatusVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"UPDATE Studentdetails Set IsActive = @IsActive where StudentId = @StudentID";
            using var con = new SqlConnection( connectionstring) ;
            con.Open();
            var parameter = new { IsActive = model.IsActive, StudentId = model.StudentId };
            int result = await con.ExecuteAsync(query, parameter);
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

        public async Task<ResponseVM> UpdateStudent(UpdateStudentVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"UPDATE Studentdetails SET TeacherId = @TeacherId, StudentName = @StudentName , FatherName =  @FatherName, Age = @Age, CNIC = @CNIC , DOB = @DOB , Religion = @Religion , AdmissionDate = @AdmissionDate , DepartmentId = @DepartmentId, Semester = @Semester , Email = @Email , Phone = @Phone , City = @City , State = @State , Country = @country  Where StudentId = @StudentId";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new { TeacherId = model.TeacherId, StudentName = model.StudentName, FatherName = model.FatherName, Age = model.Age, CNIC = model.CNIC, DOB = model.DOB, Religion = model.Religion, AdmissionDate = model.AdmissionDate, DepartmentId = model.DepartmentId, Semester = model.Semester, Email = model.Email, Phone = model.Phone, City = model.City, State = model.State, Country = model.Country, StudentId = model.StudentId};
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Update operation Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Updated Successfully";
            return response;
        }
    }
}
