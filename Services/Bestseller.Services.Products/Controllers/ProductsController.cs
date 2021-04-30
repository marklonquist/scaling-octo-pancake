using Bestseller.Database;
using Bestseller.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Bestseller.Services.Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IRepository<Product, int> _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IRepository<Product, int> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public List<Product> Get()
        {
            return _productRepository.Get();
        }

        [Route("{id}")]
        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }
    }
}
