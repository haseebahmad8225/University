using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.DataTransferModels;
using University.Interfaces;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesScheduleController : ControllerBase
    {
        private readonly IClassesSchedule _ClassesScheduleServices;
        public ClassesScheduleController(IClassesSchedule ClassesScheduleServices)
        {
            _ClassesScheduleServices = ClassesScheduleServices;
        }
        [HttpGet("GetAllClassesSchedules")]
        public async Task<IActionResult> GetClassSchedule()
        {
            var result = await _ClassesScheduleServices.GetClassSchedule();
            return Ok(result);
        }
        [HttpPost("CreateClassesSchedule")]
        public async Task<IActionResult> CreateClassSchedule(CreateClassVM model)
        {
            var result = await _ClassesScheduleServices.CreateClassSchedule(model);
            return Ok(result);
        }
        [HttpPost("UpdateClassesSchedule")]
        public async Task<IActionResult> UpdateClassSchedule(UpdateClassVM model)
        {
            var result = await _ClassesScheduleServices.UpdateClassSchedule(model);
            return Ok(result);
        }
        [HttpDelete("DeleteClassesSchedule")]
        public async Task<IActionResult> DeleteClassSchedule(long ClassId)
        {
            var result = await _ClassesScheduleServices.DeleteClassSchedule(ClassId);
            return Ok(result);
        }
        [HttpGet("GetTeacherDepartment")]
        public async Task<IActionResult> GetTeacherDepartment()
        {
            var result = await _ClassesScheduleServices.GetTeacherDepartment();
            return Ok(result);
        }
        [HttpGet("GetIndividualTeacher")]
        public async Task<IActionResult> GetIndividualTeacher(long TeacherID)
        {
            var result = await _ClassesScheduleServices.GetIndividualTeacher(TeacherID);
            return Ok(result);
        }
    }
}
