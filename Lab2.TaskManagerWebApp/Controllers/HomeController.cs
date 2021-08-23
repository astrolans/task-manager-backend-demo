using Lab2.DataAccessLayer;
using Lab2.TaskManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.TaskManagerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskManagerContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(TaskManagerContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _context.Tasks
                .Include(t => t.Users)
                .OrderBy(t => t.BeginDateTime)
                .ToListAsync();
            return View(tasks);
        }

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
