using Application.DataTransferModels.ResponseModels;
using University.DataTransferModels;

namespace University.Interfaces
{
    public interface IClassesSchedule
    {
        Task<ResponseVM> CreateClassSchedule(CreateClassVM model);

        Task<ResponseVM> UpdateClassSchedule(UpdateClassVM model);

        Task<ResponseVM> DeleteClassSchedule(long ClassId);

        Task<ResponseVM> GetClassSchedule();
        Task<ResponseVM> GetTeacherDepartment();

        Task<ResponseVM> GetIndividualTeacher(long TeacherId);
        Task<ResponseVM> GetIndividualSchedule(long ClassId);
    }
}
