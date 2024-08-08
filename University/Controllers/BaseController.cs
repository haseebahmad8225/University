using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Interfaces;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        
            private readonly IBase _BaseServices;
            public BaseController(IBase BaseServices)
            {
                _BaseServices = BaseServices;
            }
        [HttpGet("GetBase")]
        public async Task<IActionResult> GetBase(string PlainText)
        {
            var result =  _BaseServices.GetBase(PlainText);
            return Ok(result);
        }
    }

}

