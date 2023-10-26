using PetStore.data;
using PetStore.Logic;
using PetStore.Models;
using PetStore.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    internal class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _repository;

        public ProductLogic(IProductRepository productRepository)
        {
            _repository = productRepository;

        }

        public void AddProduct(ProductEntity product)
        {
            _repository.Create(product);
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _repository.GetAll().ToList();
        }

        public ProductEntity GetProductById(int id)
        {
            return _repository.Get(id);
        }
    }
}