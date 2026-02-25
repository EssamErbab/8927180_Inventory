using _8927180_Maintenance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace _8927180_Maintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
	{
		private readonly IRepairHistoryService _service;
		private readonly Dictionary<string, int> _usageCount;
		public MaintenanceController(IRepairHistoryService service, Dictionary<string, int> usageCount)
        {
            _service = service;
			_usageCount = usageCount;
		}

		[HttpGet("usage")]
		public IActionResult Usage()
		{
			var key = Request.Headers["X-Api-Key"].ToString();
			if (!_usageCount.ContainsKey(key))
				_usageCount[key] = 0;
			_usageCount[key]++;
			return Ok(new
			{
				clientId = key,
				callCount = _usageCount[key]
			});
		}

		[HttpGet("vehicles")]
		public IActionResult GetAllVehicles()
		{
			var vehicles = _service.GetAll();
			return Ok(vehicles);
		}

		// Get Vehicle By id
		[HttpGet("vehicles/{vehicleId}/repairs")]
        public IActionResult GetRepairHistory(int vehicleId)
        {
            var history = _service.GetByVehicleId(vehicleId);
            return Ok(history);
        }

		// Add Repair History
		[HttpPost]
		public IActionResult AddRepair([FromBody] RepairHistoryDTO repair)
		{
			if (repair.VehicleId <= 0)
			{
				return BadRequest(new
				{
					error = "Invalid Parameter",
					message = "Error: VehicleId must be > 0."
				});
			}

			if (string.IsNullOrWhiteSpace(repair.Description))
			{
				return BadRequest(new
				{
					error = "Invalid Parameter",
					message = "Error: Description must not be empty."
				});
			}

			if (repair.Cost < 0)
			{
				return BadRequest(new
				{
					error = "Invalid Parameter",
					message = "Error: Cost cannot be negative."
				});
			}

			var created = _service.AddRepair(repair);
			return CreatedAtAction(
			nameof(GetRepairHistory),
			new { vehicleId = created.VehicleId },
			created
			);
		}

		[HttpGet("crash")]
		public IActionResult Crash()
		{
			int x = 0;
			int y = 5 / x;
			return Ok();
		}
	}
}
