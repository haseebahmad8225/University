using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using University.DataTransferModels;
using University.Interfaces;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentService;

        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudent()
        {
            var result = await _studentService.GetStudents();
            return Ok(result);
        }   
        [HttpPost("CreateStudents")]
        public async Task<IActionResult> CreateStudent(CreateStudentVM model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.CreateStudent(model);
            return Ok(result);
        }
        [HttpPost("UpdateStudents")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.UpdateStudent(model);
            return Ok(result);
        }
        [HttpDelete("DeleteStudents")]
        public async Task<IActionResult> DeleteStudent(long StudentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.DeleteStudent(StudentId);
            return Ok(result);
        }
        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(UpdateStatusVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.UpdateStatus(model);
            return Ok(result);
        }
    }
}
    