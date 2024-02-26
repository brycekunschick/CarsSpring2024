using CarsSpring2024.Data;
using CarsSpring2024.Models;
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


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create(Make makeObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Makes.Add(makeObj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Make");
            }

            return View(makeObj);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Make make = _dbContext.Makes.Find(id);

            return View(make);
        }

        [HttpPost]

        public IActionResult Edit(int id, [Bind("MakeID, Name, Description")] Make makeObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Makes.Update(makeObj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Make");
            }

            return View(makeObj);
        }
    }
}
