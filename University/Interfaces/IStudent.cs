using Application.DataTransferModels.ResponseModels;
using University.DataTransferModels;

namespace University.Interfaces
{
    public interface IStudent
    {
        Task<ResponseVM> CreateStudent(CreateStudentVM model);

        Task<ResponseVM> UpdateStudent(UpdateStudentVM model);

        Task<ResponseVM> DeleteStudent(long Studentid);

        Task<ResponseVM> GetStudents();
        Task<ResponseVM> UpdateStatus(UpdateStatusVM model);
        
    }
}
