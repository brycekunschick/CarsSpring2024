using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarsSpring2024.Models
{
    public class Make
    {
        public int MakeId { get; set; }
        [DisplayName("Make Name: ")]
        [Required(ErrorMessage = "The name for the make MUST be provided")]
        public string Name { get; set; }
        [DisplayName("Make Description: ")]
        [Required(ErrorMessage = "The make description MUST be provided")]
        public string Description { get; set; }
    }
}
