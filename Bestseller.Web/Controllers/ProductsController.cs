using Bestseller.Database;
using Bestseller.Database.Interfaces;
using Bestseller.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bestseller.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IRepository<Product, int> _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IRepository<Product, int> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var allProducts = _productRepository.GetAll();

            return View(new ProductsModel
            {
                Products = allProducts,
            });
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.Get(id);

            return View(new ProductModel
            {
                Product = product,
            });
        }
    }
}
