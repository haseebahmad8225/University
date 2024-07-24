using System.Threading.Tasks;
using Application.DataTransferModels.ResponseModels;
using University.DataTransferModels;
namespace University.Interfaces
{
    public interface IUniversity
    {
        Task<ResponseVM> CreateUniversity(CreateUniversityVM model);
        Task<ResponseVM> UpdateUniversity(UpdateUniversityVM model);
        Task<ResponseVM> DeleteUniversity(long UniversityId);
        Task<ResponseVM> GetUniversity();
        Task<ResponseVM> GetAllDepartments(long UniversityId);
    }
}
