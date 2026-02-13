using _8927180_maintenance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace _8927180_maintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly IRepairHistoryService _service;
        public MaintenanceController(IRepairHistoryService service)
        {
            _service = service;
        }
        [HttpGet("vehicles/{vehicleId}/repairs")]
        public IActionResult GetRepairHistory(int vehicleId)
        {
            var history = _service.GetByVehicleId(vehicleId);
            return Ok(history);
        }
    }
}
