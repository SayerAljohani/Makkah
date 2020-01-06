using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MakkahDbContext _context;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, MakkahDbContext context,
            IRepository repository)
        {
            _context = context;
            _logger = logger;
            _repository = repository;

        }

        public IActionResult Index()
        {
            ViewBag.number = _repository.GetAll();
            ViewBag.student = _repository.GetFingers("student");
            return View();
        }

        public IActionResult Privacy()
        {
            return Content("test");
        }

        public IActionResult Maps()
        {
            return View();
        }

        public IActionResult LiveMap()
        {
            return View();
        }

      
        [HttpGet]
        public Statistic GetFingers()
        {
            return _repository.GetData(); ;
        }

        [HttpGet]
        public async Task<string> FingerPrint(string category)
        {
            if (category == null || category == "")
                category = "not selected";
            var p = new Person();
            p.Category = category;
            p.CreatedDate = DateTime.Now;
            _context.Persons.Add(p);
            _ = await _context.SaveChangesAsync();
            return p.Category;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
