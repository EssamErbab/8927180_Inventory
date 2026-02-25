using _8927180_Inventory.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _8927180_Inventory.MVC.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MaintenanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Usage()
        {
            var client = _httpClientFactory.CreateClient("MaintenanceAPI");
            var response = await client.GetAsync("api/Maintenance/usage");
            return View(response);
        }

        [HttpGet]
        public IActionResult History()
        {
            return View(new List<RepairHistoryViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> History(int vehicleId)
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");
            var repairs = await client.GetFromJsonAsync<List<RepairHistoryViewModel>>(
            $"api/maintenance/vehicles/{vehicleId}/repairs");
            return View(repairs ?? new List<RepairHistoryViewModel>());
        }
    }
}