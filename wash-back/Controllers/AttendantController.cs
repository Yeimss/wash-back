using core.Interfaces.Services.Attendant;
using DTOs.Attendant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wash_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AttendantController : Controller
    {
        private readonly IAttendantService _attendantService;
        public AttendantController(IAttendantService attendant) 
        {
            _attendantService = attendant;
        }
        [HttpGet]
        [Route("GetAll/{idEnterprice?}")]
        public async Task<IActionResult> GetAll(int? idEnterprice)
        {
            var claims = User.Claims;
            var result = await _attendantService.GetAll(claims, idEnterprice);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AttendantDto attendant)
        {
            var claims = User.Claims;
            var result = await _attendantService.Insert(attendant, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(AttendantUpdateDto attendant)
        {
            var claims = User.Claims;
            var result = await _attendantService.Update(attendant, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var claims = User.Claims;
            var result = await _attendantService.Delete(id, claims);
            return StatusCode(result.StatusCode, result);
        }
    }
}
