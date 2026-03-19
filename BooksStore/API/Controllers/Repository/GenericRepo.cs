using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Interface;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Repository
{
    public class GenericRepo<T> : IGenericDetail<T> where T : class
    {
    private readonly StoreContext _context;

       

        public GenericRepo(StoreContext context)
     {
            _context = context;

     }

        public string AddDetail(T data)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public List<T> GetDetail()
        {
            return _context.Set<T>().ToList();
        }
    }
}