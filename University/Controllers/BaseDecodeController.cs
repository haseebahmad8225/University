using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Interfaces;
using University.Services;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDecodeController : ControllerBase
    {
        private readonly IBaseDecode _BaseDecodeServices;
        public BaseDecodeController(IBaseDecode BaseDecodeServices)
        {
            _BaseDecodeServices = BaseDecodeServices;
        }
        [HttpGet("GetBaseDecode")]
        public async Task<IActionResult> GetBaseDecode(string PlainText)
        {
            var result = _BaseDecodeServices.GetBaseDecode(PlainText);
            return Ok(result);
        }
    }
}
