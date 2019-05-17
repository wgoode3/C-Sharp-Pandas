using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pandas.Models;

namespace Pandas.Controllers
{
    public class DishController : Controller
    {

        private PandaContext context;

        public DishController(PandaContext dbcontext)
        {
            context = dbcontext;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Dishes = context.Dishes;
            return View();
        }

        [Route("new")]
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Dish d)
        {
            if(ModelState.IsValid)
            {
                context.Create(d);
            }
            return Redirect("/");
        }

        [Route("dish/{DishId}")]
        [HttpGet]
        public IActionResult Edit(int DishId)
        {
            return View(context.GetDishById(DishId));   
        }

        [Route("update/{DishId}")]
        [HttpPost]
        public IActionResult Update(int DishId, Dish d)
        {
            context.Update(d);
            return Redirect("/");   
        }

        [Route("delete/{DishId}")]
        [HttpPost]
        public IActionResult Delete(int DishId)
        {
            context.DeleteById(DishId);
            return Redirect("/");   
        }

    }
}
