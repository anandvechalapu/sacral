using Microsoft.AspNetCore.Mvc;
using Sacral.DTO;
using Sacral.Service;

namespace Sacral.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly UserManagementControllerService _userManagementControllerService;

        public UserManagementController(UserManagementControllerService userManagementControllerService)
        {
            _userManagementControllerService = userManagementControllerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserManagementControllerModel>>> GetAllAsync()
        {
            var result = await _userManagementControllerService.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserManagementControllerModel>> GetByIdAsync(int id)
        {
            var result = await _userManagementControllerService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserManagementControllerModel>> AddAsync([FromBody] UserManagementControllerModel user)
        {
            await _userManagementControllerService.AddAsync(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserManagementControllerModel>> UpdateAsync([FromBody] UserManagementControllerModel user)
        {
            await _userManagementControllerService.UpdateAsync(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _userManagementControllerService.DeleteAsync(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}