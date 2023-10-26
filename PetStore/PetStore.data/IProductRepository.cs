using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.data
{
    public interface IProductRepository
    {
        public void Create(ProductEntity product);
        public ProductEntity? Get(int id);
        public IQueryable<ProductEntity> GetAll();


    }
}
