using CarsSpring2024.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarsSpring2024.Controllers
{
    public class MakeController : Controller
    {
        private CarsDbContext _dbContext;

        public MakeController(CarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()//list or fetch all objects (categories)
        {
            var listOfMakes = _dbContext.Makes.ToList();

            return View(listOfMakes);
        }
    }
}
