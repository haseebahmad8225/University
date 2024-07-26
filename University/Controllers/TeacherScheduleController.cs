using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.DataTransferModels;
using University.Interfaces;
using University.Services;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherScheduleController : ControllerBase
    {
        private readonly ITeacherSchedule _teacherScheduleServices;
        public TeacherScheduleController(ITeacherSchedule TeacherScheduleServices)
        {
            _teacherScheduleServices = TeacherScheduleServices;
        }
        [HttpGet("GetTeacherSchedule")]
        public async Task<IActionResult> GetTeacherSchedule()
        {
            var result = await _teacherScheduleServices.GetTeacherSchedule();
            return Ok(result);
        }
        [HttpPost("CreateTeacherSchedule")]
        public async Task<IActionResult> CreateTeacherSchedule(CreateTeacherScheduleVM model)
        {
            var result = await _teacherScheduleServices.CreateTeacherSchedule(model);
            return Ok(result);
        }
        [HttpPost("UpdateTeacherSchedule")]
        public async Task<IActionResult> UpdateTeacherschedule(UpdateTeacherScheduleVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _teacherScheduleServices.UpdateTeacherSchedule(model);
            return Ok(result);
        }
        [HttpDelete("DeleteTeacherSchedule")]
        public async Task<IActionResult> DeleteTeacherSchedule(long Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _teacherScheduleServices.DeleteTeacherSchedule(Id);
            return Ok(result);
        }
        [HttpGet("GetAllSchedule")]
        public async Task<IActionResult> GetAllSchedule()
        {
            var result = await _teacherScheduleServices.GetAllSchedule();
            return Ok(result);
        }
    }
}
