using Bestseller.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bestseller.Database.Repositories
{
    public class CategoryRepository : IRepository<Category, string>
    {
        private MockData _mockData { get; set; }

        public CategoryRepository(MockData mockData)
        {
            _mockData = mockData;
        }

        public List<Category> Get(params string[] ids)
        {
            return _mockData.DB.Categories.FindAll(x => ids.Contains(x.Id));
        }

        public List<Category> Get()
        {
            return _mockData.DB.Categories;
        }

        public Category Get(string id)
        {
            return _mockData.DB.Categories.Find(x => x.Id == id);
        }
    }
}
