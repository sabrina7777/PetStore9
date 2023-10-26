using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.data
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;
        public ProductRepository()
        { 
            context = new ProductContext(); 
        }
        public void Create(ProductEntity product) 
        {
            context.Products.Add(product);
            int created = context.SaveChanges();
            
        }
    }
}
