using core.Interfaces.Services.Attendant;
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
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
