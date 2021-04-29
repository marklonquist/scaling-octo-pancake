using Bestseller.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bestseller.Database.Repositories
{
    public class ProductRepository : IRepository<Product, int>
    {
        private MockData _mockData { get; set; }

        public ProductRepository(MockData mockData)
        {
            _mockData = mockData;
        }

        public List<Product> GetMultiple(params int[] ids)
        {
            return _mockData.DB.Products.FindAll(x => ids.Contains(x.Id));
        }

        public List<Product> GetAll()
        {
            return _mockData.DB.Products;
        }

        public Product Get(int id)
        {
            return _mockData.DB.Products.Find(x => x.Id == id);
        }
    }
}
