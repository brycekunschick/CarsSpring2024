using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsSpring2024.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [DisplayName("Car Model")]
        public string Model { get; set; }

        public decimal Price { get; set; }

        public int MakeId { get; set; }
        [ForeignKey("MakeId")]
        public Make Make { get; set; } //navigational property
    }
}
