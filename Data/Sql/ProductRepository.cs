using Core;
using Data.Interface;
using System.Collections.Generic;
using System.Linq;


namespace Data.Sql
{
    public class ProductRepository
    {
        private readonly UjpDbContext ujpDbContext;

        public ProductRepository(UjpDbContext ujpDbContext)
        {
            this.ujpDbContext = ujpDbContext;
        }

        public int Count()
        {
            return ujpDbContext.Products.Count();
        }
        public double Sum()
        {
            var products = ujpDbContext.Products.ToList();
            double sum = 0;
            foreach(Product product in products)
            {
                sum = sum + product.Price;
            }
            return sum;
        }

    }
}
