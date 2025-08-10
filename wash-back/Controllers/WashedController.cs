using core.Interfaces.Services.Washed;
using DTOs.Washed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wash_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WashedController : Controller
    {
        private readonly IWashedService _washedService;
        public WashedController(IWashedService washedService)
        {
            _washedService = washedService;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromBody] WashedFiltersDto filters)
        {
            var claims = User.Claims;
            var result = await _washedService.GetAll(filters, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var claims = User.Claims;
            var result = await _washedService.Get(id, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(WashedDto washed)
        {
            var claims = User.Claims;
            var result = await _washedService.Insert(washed, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(WashedUpdateDto washedUpdateDto)
        {
            var claims = User.Claims;
            var result = await _washedService.Update(washedUpdateDto, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var claims = User.Claims;
            var result = await _washedService.Delete(id, claims);
            return StatusCode(result.StatusCode, result);
        }
    }
}
