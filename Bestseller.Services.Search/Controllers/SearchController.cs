using Bestseller.Database;
using Bestseller.Database.Interfaces;
using Bestseller.SearchIndex;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bestseller.SearchIndex.Indexer;

namespace Bestseller.Services.Search.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly Indexer _searchIndex;

        public SearchController(ILogger<SearchController> logger, Indexer searchIndex)
        {
            _logger = logger;
            _searchIndex = searchIndex;
        }

        [HttpGet("{searchPhrase}")]
        public IEnumerable<ResultValue> Get(string searchPhrase)
        {
            return _searchIndex.Search(searchPhrase);
        }
    }
}
