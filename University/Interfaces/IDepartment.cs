using Application.DataTransferModels.ResponseModels;
using University.DataTransferModels;

namespace University.Interfaces
{
    public interface IDepartment
    {
        Task<ResponseVM> CreateDepartment(CreateDepartmentVM model);

        Task<ResponseVM> UpdateDepartment(UpdateDepartmentVM model);

        Task<ResponseVM> DeleteDepartment(long Departmentid);

        Task<ResponseVM> GetDepartments();

        Task<ResponseVM> GetAllStudents(long DepartmentId);
        Task<ResponseVM> GetAllTeachers(long DepartmentId);

        Task<ResponseVM> AssignHeadRole(AssignHeadRoleVM model);
    }
}
