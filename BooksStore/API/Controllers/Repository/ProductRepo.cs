using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Interface;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly StoreContext _db;
        public ProductRepo(StoreContext db)
        {
            _db = db;
        }

        public string AddProduct(Product product)
        {
            //try
            //{
                if (product is null || String.IsNullOrEmpty(product.Name))
                {
                    return "Data is  null please provide some data";
                }
                _db.Add(product);
                _db.SaveChanges();
                return "Data Added Successfully";
            //}
            //catch (Exception ex)
            //{
            //   Console.WriteLine("Exception occur ar AddproductMethod + " + ex.ToString());
            //}
            //return "Data Not Added";
                
        }

        public async Task<string> Delete(int id)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x=>x.Id==id);
            if(product is null || String.IsNullOrEmpty(product.Name))
            {
             return "No Data Associated with given Id";
            }
            _db.Products.Remove(product);
             await _db.SaveChangesAsync();
            return "Data Deleted Successfully";
        }

        public async Task <List<Product>> GetProducts()
        {
            return  await _db.Products
            .ToListAsync();
        }

        public Task<Product> Update(Product pr)
        {
            throw new NotImplementedException();
        }
    }
}