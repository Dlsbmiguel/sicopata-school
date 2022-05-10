using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SicopataSchool.Model.Entities;
using SicopataSchool.Services.Services;

namespace SicopataSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly IJWTManagerService _jwtService;
        public LogInController(IJWTManagerService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Student student)
        {

            var token = _jwtService.GetTokenAsync(student);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
