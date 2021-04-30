using Bestseller.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bestseller.Frontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private string SearchAPIEndpoint;
        private string ProductsAPIEndpoint;

        public ProductsController(ILogger<ProductsController> logger, IConfiguration config)
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

        public IActionResult Details(int id)
        {
            ViewBag.ProductId = id;

            return View(new EndpointModel
            {
                SearchAPIEndpoint = this.SearchAPIEndpoint,
                ProductsAPIEndpoint = this.ProductsAPIEndpoint,
            });
        }
    }
}
