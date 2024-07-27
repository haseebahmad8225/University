using Application.DataTransferModels.ResponseModels;
using University.DataTransferModels;

namespace University.Interfaces
{
    public interface ITeacherSchedule
    {
        Task<ResponseVM> CreateTeacherSchedule(CreateTeacherScheduleVM model);
        Task<ResponseVM> UpdateTeacherSchedule(UpdateTeacherScheduleVM model);
        Task<ResponseVM> GetTeacherSchedule();
        Task<ResponseVM> DeleteTeacherSchedule(long Id);
        Task<ResponseVM> GetAllSchedule(long TeacherId);
    }
}
