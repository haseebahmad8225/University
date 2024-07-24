using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.DataTransferModels;
using University.Interfaces;
using University.Model;
using University.Services;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;
        public DepartmentController(IDepartment departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartment()
        {
            var result = await _departmentService.GetDepartments();
            return Ok(result);
        }
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _departmentService.CreateDepartment(model);
            return Ok(result);
        }

        [HttpPost("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _departmentService.UpdateDepartment(model);  
            return Ok(result);
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(long DepartmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _departmentService.DeleteDepartment(DepartmentId);
            return Ok(result);
        }
        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents(long DepartmentId)
        {
            var result = await _departmentService.GetAllStudents(DepartmentId);
            return Ok(result);
        }
        [HttpGet("GetAllTeachers")]
        public async Task<IActionResult> GetAllTeachers(long DepartmentId)
        {
            var result = await _departmentService.GetAllTeachers(DepartmentId);
            return Ok(result);
        }
        [HttpPost("AssignHeadRole")]
        public async Task<IActionResult> AssignHeadRole(AssignHeadRoleVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _departmentService.AssignHeadRole(model);
            return Ok(result);
        }
    }
}
