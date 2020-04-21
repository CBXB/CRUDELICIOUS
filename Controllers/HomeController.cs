using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Http;


namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context { get; set; }
        public HomeController(MyContext context)
        {
            _context = context;
        }

        //localhost:5000/
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish>AllDishes = _context.Dishess.OrderByDescending(x => x.CreatedAt).ToList();
            return View(AllDishes);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("{tempId}")]
        public IActionResult Dish(int tempId)
        {
            Dish singleDish = _context.Dishess.SingleOrDefault(x=> x.DishId == tempId);
            return View(singleDish);
        }

        [HttpGet("edit/{tempId}")]
        public IActionResult EditDish(int tempId)
        {
            Dish singleDish = _context.Dishess.SingleOrDefault(x => x.DishId == tempId);
            return View(singleDish);

        }

        [HttpPost("edit/{tempId}")]
        public IActionResult Edit(int tempId, Dish editDish)
        {
            if(ModelState.IsValid)
            {
                Dish singleDish = _context.Dishess.SingleOrDefault(x => x.DishId == tempId);
                singleDish.ChefName = editDish.ChefName;
                singleDish.DishName = editDish.DishName;
                singleDish.Calories = editDish.Calories;
                singleDish.Tastiness = editDish.Tastiness;
                singleDish.Description = editDish.Description;
                singleDish.Updated = DateTime.Now;
                _context.SaveChanges();
                return Redirect($"/{tempId}");
            }
            else
            {
                return View("EditDish", editDish);
            }

        }

        [HttpGet("delete/{tempId}")]
        public IActionResult Delete(int tempId)
        {
            Dish deleteDish = _context.Dishess.SingleOrDefault(x => x.DishId == tempId);
            _context.Dishess.Remove(deleteDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        
// =============================================================================================
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
}
}
