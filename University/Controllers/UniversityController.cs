using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.DataTransferModels;
using University.Interfaces;
using University.Services;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversity _UniversityServices;
        public UniversityController(IUniversity UniversityServices)
        {
            _UniversityServices = UniversityServices;
        }
        [HttpGet("GetUniversity")]
        public async Task<IActionResult> GetUniversity()
        {
            var result = await _UniversityServices.GetUniversity();
            return Ok(result);
        }
        [HttpPost("CreateUniversity")]
        public async Task<IActionResult> CreateUniversity(CreateUniversityVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _UniversityServices.CreateUniversity(model);
            return Ok(result);
        }
        [HttpPost("UpdateUniversity")]
        public async Task<IActionResult> UpdateUniversity(UpdateUniversityVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _UniversityServices.UpdateUniversity(model);
            return Ok(result);
        }
        [HttpDelete("DeleteUniversity")]
        public async Task<IActionResult> DeleteUniversity(long UniversityId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _UniversityServices.DeleteUniversity(UniversityId);
            return Ok(result);
        }
        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments(long DepartmentId)
        {
            var result = await _UniversityServices.GetAllDepartments(DepartmentId);
            return Ok(result);
        }
    }
}
