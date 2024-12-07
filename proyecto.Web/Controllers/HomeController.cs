using Microsoft.AspNetCore.Mvc;
using proyecto.Web.Models;
using System.Diagnostics;
using proyecto.Domain.Entities;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace proyecto.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = "Home";
            return View();
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
