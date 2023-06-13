using Sacral.DTO;
using Sacral.Service;
using Microsoft.AspNetCore.Mvc;

namespace Sacral.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly LogoutServiceImpl _logoutServiceImpl;

        public LogoutController(LogoutServiceImpl logoutServiceImpl)
        {
            _logoutServiceImpl = logoutServiceImpl;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync(LogoutDto logoutDto)
        {
            bool result = await _logoutServiceImpl.LogoutAsync(logoutDto.UserId);

            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}