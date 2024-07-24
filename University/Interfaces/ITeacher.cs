using Application.DataTransferModels.ResponseModels;
using University.DataTransferModels;

namespace University.Interfaces
{
    public interface ITeacher
    {
        Task<ResponseVM> CreateTeacher(CreateTeacherVM model);
        Task<ResponseVM> UpdateTeacher(UpdateTeacherVM model);
        Task<ResponseVM> DeleteTeacher(long TeacherId);
        Task<ResponseVM> GetTeachers();
        Task<ResponseVM> AssignTeacherStudent(TeacherStudentAsignVM model);
    }
}
