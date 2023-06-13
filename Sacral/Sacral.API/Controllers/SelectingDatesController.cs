using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sacral.DTO;
using Sacral.Service;

namespace Sacral.API
{
    [Route("api/[controller]")]
    public class SelectingDatesController : Controller
    {
        private readonly SelectingDatesService _selectingDatesService;

        public SelectingDatesController(SelectingDatesService selectingDatesService)
        {
            _selectingDatesService = selectingDatesService;
        }

        [HttpGet]
        public async Task<ActionResult<SelectingDates>> SelectingDates()
        {
            var result = await _selectingDatesService.SelectingDates();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}