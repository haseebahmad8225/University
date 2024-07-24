using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.DataTransferModels;
using University.Interfaces;
using University.Services;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacherService;
        public TeacherController(ITeacher teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet("GetTeachers")]
        public async Task<IActionResult> GetTeacher()
        {
            var result = await _teacherService.GetTeachers();
            return Ok(result);
        }
        [HttpPost("CreateTeachers")]
        public async Task<IActionResult> CreateTeachers(CreateTeacherVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _teacherService.CreateTeacher(model);
            return Ok(result);
        }
        [HttpPost("UpdateTeachers")]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _teacherService.UpdateTeacher(model);
            return Ok(result);
        }
        [HttpDelete("DeleteTeachers")]
        public async Task<IActionResult> DeleteTeacher(long TeacherId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _teacherService.DeleteTeacher(TeacherId);
            return Ok(result);
        }
        [HttpPost("TeacherStudentAsign")]
        public async Task<IActionResult> TeacherStudentAsign(TeacherStudentAsignVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _teacherService.AssignTeacherStudent(model);
            return Ok(result);
        }
    }
}
