using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.data
{
    public class ProductRepository : IProductRepository
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
        public ProductEntity? Get(int id)
        {
            return context.Products.SingleOrDefault(p => p.ProductId == id);
        }

        //IEnumerale or better to IQueryable instead of IEnumerable; prevents it from querying immediately so if you want to do a filter,
        //modify the sql wuery before sending it to the database. IEnumerable causes it to select all
        public IQueryable<ProductEntity> GetAll()
        {
            return context.Products;
        }
        
    }
}
