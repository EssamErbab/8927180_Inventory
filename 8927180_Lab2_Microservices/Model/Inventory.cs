using System.ComponentModel.DataAnnotations;

namespace _8927180_Lab2_Microservices.Model
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; } = 0;
        [Required]
        public int Amount { get; set; }
    }
}
