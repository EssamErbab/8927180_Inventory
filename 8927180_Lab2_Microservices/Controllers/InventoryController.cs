using Microsoft.AspNetCore.Mvc;
using _8927180_Lab2_Microservices.Data;
using _8927180_Lab2_Microservices.Model;

namespace _8927180_Lab2_Microservices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext context;
        public InventoryController(AppDbContext context) { this.context = context; }

        [HttpGet]
        public ActionResult GetInventory() => Ok(context.Inventory.ToList());

        [HttpGet("{id}")]
        public ActionResult GetItem(int id)
        {
            var item = context.Inventory.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public ActionResult InsertItem(Inventory item)
        {
            context.Inventory.Add(item);
            context.SaveChanges();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, Inventory item)
        {
            var exists = context.Inventory.Find(id);
            if (exists == null)
                return NotFound();

            exists = item;
            exists.Id = id;

            context.Inventory.Update(item);

            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var exists = context.Inventory.Find(id);
            if ( exists == null)
                return NotFound();

            context.Remove(exists);
            context.SaveChanges();

            return NoContent();
        }
    }
}
