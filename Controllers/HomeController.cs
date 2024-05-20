using Microsoft.AspNetCore.Mvc;
using PrevisaoEcommerce.Models;
using PrevisaoEcommerce.Persistence;
using System.Diagnostics;

namespace PrevisaoEcommerce.Controllers
{
    public class HomeController : Controller
    {

        private SprintDbContext dbContext { get; set; }


        public HomeController(SprintDbContext context)
        {
            dbContext = context;

        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
