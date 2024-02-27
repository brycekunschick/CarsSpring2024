using CarsSpring2024.Data;
using CarsSpring2024.Models;
using CarsSpring2024.Models.ViewModels;
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


        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> listOfMakes = _dbContext.Makes.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.MakeId.ToString()
            });

            CarWithMakesVM carWithMakesVMobj = new CarWithMakesVM();

            carWithMakesVMobj.Car = new Car();

            carWithMakesVMobj.ListOfMakes = listOfMakes;

            return View(carWithMakesVMobj);

        }

        [HttpPost]
        public IActionResult Create(CarWithMakesVM CarWithMakesVMobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Cars.Add(CarWithMakesVMobj.Car);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Car");
            }

            return View(CarWithMakesVMobj);
        }

    }
}
