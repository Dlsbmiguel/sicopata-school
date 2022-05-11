using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SicopataSchool.Bl.Dtos;
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
        public IActionResult Authenticate(LogInDto student)
        {

            var token = _jwtService.GetToken(student);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
