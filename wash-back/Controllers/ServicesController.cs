using core.Entities.Cliente;
using core.Interfaces.Services.IServicesService;
using DTOs.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wash_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;
        public ServicesController(IServicesService service)
        {
            _servicesService = service;
        }
        [HttpGet]
        [Route("Get/{idEnterprice?}")] //opcional para que el admin pueda consultar una empresa en espécifico
        public async Task<IActionResult> Get(int? idEnterprice)
        {
            var claims = User.Claims;
            var result = await _servicesService.GetServices(claims, idEnterprice);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        [Route("Category/Get")]
        public async Task<IActionResult> GetCategory()
        {
            var result = await _servicesService.GetCategoryServices();
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ServiceDto service)
        {
            var claims = User.Claims;
            var result = await _servicesService.InsertService(service, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(ServiceUpdateDto service)
        {
            var claims = User.Claims;
            var result = await _servicesService.UpdateServices(service, claims);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var claims = User.Claims;
            var result = await _servicesService.DeleteService(id, claims);
            return StatusCode(result.StatusCode, result);
        }
    }
}
