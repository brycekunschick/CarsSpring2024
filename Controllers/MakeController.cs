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
            //custom validation 1
            if (makeObj.Name != null && makeObj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("Name", "Make name cannot be 'test'");
            }

            //custom validation to make sure that name and description values are not exactly the same
            if (makeObj.Name == makeObj.Description)
            {
                ModelState.AddModelError("Description", "Make name and description cannot be the same");
            }



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

        public IActionResult Edit(int id, [Bind("MakeId, Name, Description")] Make makeObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Makes.Update(makeObj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Make");
            }

            return View(makeObj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Make make = _dbContext.Makes.Find(id);

            return View(make);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Make makeObj = _dbContext.Makes.Find(id);

            _dbContext.Makes.Remove(makeObj);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Make");
        }
    }
}
