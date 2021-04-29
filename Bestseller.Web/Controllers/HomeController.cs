using Bestseller.Database;
using Bestseller.Database.Interfaces;
using Bestseller.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bestseller.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string SearchAPIEndpoint;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            SearchAPIEndpoint = config.GetServiceUri("bestseller-services-search").ToString();
        }

        public IActionResult Index()
        {
            return View(new HomeModel
            {
                SearchAPIEndpoint = this.SearchAPIEndpoint,
            });
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
