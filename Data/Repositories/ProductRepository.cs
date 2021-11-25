using Data.Context;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SqlContext context) : base(context)
        {

        }

        public Product GetByID(int id)
        {
            var obj = CurrentSet
                      .Where(x => x.Id == id) 
                      .FirstOrDefault();
            return obj;
        }

        public IEnumerable<Product> GetProducts()
        {
            var obj = CurrentSet
                      .ToList();
            return obj;
        }
    }
}
