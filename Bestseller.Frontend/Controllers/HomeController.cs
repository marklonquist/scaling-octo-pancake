using Bestseller.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Bestseller.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string SearchAPIEndpoint;
        private string ProductsAPIEndpoint;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;

            SearchAPIEndpoint = config.GetServiceUri("bestseller-services-search").ToString();
            ProductsAPIEndpoint = config.GetServiceUri("bestseller-services-products").ToString();
        }

        public IActionResult Index()
        {
            return View(new EndpointModel
            {
                SearchAPIEndpoint = this.SearchAPIEndpoint,
                ProductsAPIEndpoint = this.ProductsAPIEndpoint,
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
