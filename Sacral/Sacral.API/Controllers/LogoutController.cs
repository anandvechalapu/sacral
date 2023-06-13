using Sacral.DTO;
using Sacral.Service;
using Microsoft.AspNetCore.Mvc;

namespace Sacral.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LogoutDto logoutDto)
        {
            var isLoggedOut = await _logoutService.LogoutAsync(logoutDto);
            if (isLoggedOut)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}