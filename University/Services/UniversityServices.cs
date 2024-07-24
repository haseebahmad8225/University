using Application.DataTransferModels.ResponseModels;
using Dapper;
using Microsoft.Data.SqlClient;
using University.DataTransferModels;
using University.Interfaces;
using University.Model;

namespace University.Services
{
    public class UniversityServices : IUniversity
    {
         
        private readonly IConfiguration _configuration;
        public UniversityServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseVM> CreateUniversity(CreateUniversityVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string ConnectionString = _configuration.GetConnectionString("UniversityContext");
            string query = $"Insert into UniversityDetails (Name, Location, EstablishedYear) Values (@Name, @Location, @EstablishedYear)";
            using var con = new SqlConnection(ConnectionString) ;
            con.Open();
            var parameter = new {Name = model.Name, Location = model.Location, EstablishedYear = model.EstablishedYear};    
            int result = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode = 400;
                response.errorMessage = "Insert Operation Unssuccesful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Inserted Successfully";
            return response;
        }

        public async Task<ResponseVM> DeleteUniversity(long UniversityId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionString = _configuration.GetConnectionString("UniversityContext");
            string query = $"Delete from UniversityDetails Where UniversityId = @UniversityId";
            using var con = new SqlConnection(connectionString) ;
            con.Open();
            var parameter = new {UniversityId  = UniversityId};
            int result  = await con.ExecuteAsync(query, parameter);
            if (result == 0)
            {
                response.responseCode= 400;
                response.errorMessage = "Delete Unsuccessful";
                return response;
            }
            response.responseCode = 200;
            response.responseMessage = "Deleted successfully";
            return response;
        }

        public async Task<ResponseVM> GetAllDepartments(long UniversityId)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"Select * from DepartmentDetails where UniversityId = @UniversityId";
            using var con = new SqlConnection( connectionstring) ;
            con.Open();
            var parameter = new { UniversityId = UniversityId };
            IEnumerable<Department> Departments = await con.QueryAsync<Department>(query, parameter);
            if (Departments == null)
            {
                response.responseCode = 404;
                response.errorMessage = "Department not Found";
                return response;
            }
            response.responseCode = 200;
            response.data = Departments;
            return response;
        }

        public async Task<ResponseVM> GetUniversity()
        {
            ResponseVM response = ResponseVM.Instance;
            string ConnectionString = _configuration.GetConnectionString("UniversityContext");
            string query = $"Select * from UniversityDetails";
            using var con = new SqlConnection(ConnectionString);
            con.Open();
            IEnumerable<UniversityDetails> university = await con.QueryAsync<UniversityDetails>(query);
                if (university is null)
            {
                response.responseCode = 404;
                response.errorMessage = "University not found";
                return response;
            }
            response.responseCode = 200;
            response.data = university;
            return response;
        }

        public async Task<ResponseVM> UpdateUniversity(UpdateUniversityVM model)
        {
            ResponseVM response = ResponseVM.Instance;
            string connectionstring = _configuration.GetConnectionString("UniversityContext");
            string query = $"update UniversityDetails set  Name = @Name, Location = @Location, EstablishedYear = @EstablishedYear where UniversityId = @UniversityId";
            using var con = new SqlConnection(connectionstring);
            con.Open();
            var parameter = new { Name = model.Name, Location = model.Location, EstablishedYear = model.EstablishedYear, UniversityId = model.UniversityId };
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
    }
}
