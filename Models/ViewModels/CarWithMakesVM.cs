using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarsSpring2024.Models.ViewModels
{
    public class CarWithMakesVM
    {
        public Car Car { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListOfMakes { get; set; }
    }
}
