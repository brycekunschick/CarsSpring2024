using CarsSpring2024.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarsSpring2024.Controllers
{
    public class CarController : Controller
    {
        private CarsDbContext _dbContext;

        public CarController(CarsDbContext context)
        {
            _dbContext = context; // passes the dbContext object to the instance variable. this is how you inject your database into the controller, called dependency injection

        }

        public IActionResult Index() //fetch all cars
        {
            var listOfCars = _dbContext.Cars.ToList();

            return View(listOfCars);
        }

        
        

    }
}
