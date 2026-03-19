using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Controllers.Interface
{
    public interface IProduct
    {
        public Task< List<Product>> GetProducts();

        public string AddProduct(Product product);

        public Task<string> Delete(int id);

        public Task<Product> Update(Product pr);
        
    }
}