using Bestseller.Database;
using Bestseller.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Bestseller.Services.Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IRepository<Category, string> _categoryRepository;

        public CategoriesController(ILogger<CategoriesController> logger, IRepository<Category, string> categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public List<Category> Get()
        {
            return _categoryRepository.Get();
        }

        [Route("{id}")]
        public Category Get(string id)
        {
            return _categoryRepository.Get(id);
        }
    }
}
