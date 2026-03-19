using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Interface;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Product")]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;
        private readonly IBookDetail _bookrepo;
        public ProductController(IProduct repo, IBookDetail bookrepo)
        {
            _bookrepo = bookrepo;
            _repo = repo;
        }

        [HttpGet]
        public async Task<List<Product>> Name()
        {
            var product = await _repo.GetProducts();
            return product;
        }

        [HttpPost]
        public string AddProduct(Product pr)
        {
            return _repo.AddProduct(pr);
        }

        [HttpDelete]
        public async Task<string> DeleteProduct(int id)
        {
            return await _repo.Delete(id);
        }

        [HttpPost]
        [Route("BookDetailAdd")]
        public async Task<string> BookDetailAdd(BookDetail detail)
        {
            return await _bookrepo.BookDetailAdd(detail);
        }

        [HttpGet]
        [Route("GetBookDetail")]
        public async Task<List<BookDetail>> GetBookDetail()
        {
            return await _bookrepo.GetBookDetails();
        }


        [HttpGet]
        [Route("GetBookById")]
        public async Task<BookDetail> GetBookDetailById(int id)
        {
            return await _bookrepo.BookbyId(id);
        }


        [HttpPatch]
        [Route("Get data updated")]
        public bool Update(BookDetail detail)
        {
            return _bookrepo.Updatedata(detail);
        }


        [HttpDelete]
        [Route("BookDetailDelete")]
        public bool BookDetailDelete(int id)
        {

            return _bookrepo.DeleteBookDetail(id);

        }


        //[HttpGet]
        //public void LinqMethodTest()
        //{
        //    IEnumerable<int> e = [1, 2, 3, 4, 5, 6, 7, 8, 9, 55];
        //    var result = e.Where(x => x > 5);
        //    Console.WriteLine(result);
        //}




    }

}