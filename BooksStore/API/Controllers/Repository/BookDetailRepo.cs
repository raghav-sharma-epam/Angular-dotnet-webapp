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
    public class BookDetailRepo : IBookDetail
    {
        private readonly StoreContext _db;
        public BookDetailRepo(StoreContext db)
        {
            _db = db;
        }

        public  async Task<BookDetail> BookbyId(int id)
        {
           BookDetail result =   _db.BookDetails.Include(p=>p.ProductRef)
           .FirstOrDefault(p=>p.Id == id);
           if(result != null)
           {
               return  result;
           }
            return null;
           }

        public async Task<string> BookDetailAdd(BookDetail detail)
        {
            if(detail is null|| String.IsNullOrEmpty(detail.Name))
            {
                return "Data cannot be added due to incomplete details";
            }
            var details = await _db.BookDetails.AddAsync(detail);
            await _db.SaveChangesAsync();
            return "Data Added Successfully";
        }

        public bool DeleteBookDetail(int id)
        {
           BookDetail val = _db.BookDetails.FirstOrDefault(x=>x.Id == id);
           if(val !=null)
           {
            _db.BookDetails.Remove(val);
            _db.SaveChanges();
            return true;
           }
           return false;
        }

        public async Task<List<BookDetail>> GetBookDetails()
        {
            return await _db.BookDetails.Include(p => p.ProductRef).ToListAsync();
        }

        public bool Updatedata(int id)
        {
            var data = _db.BookDetails.Find(id);
            var result = data!=null ? true : false;
            return   result;
        }

        public bool Updatedata(BookDetail bookDetail)
        {
           // var data = _db.BookDetails.FirstOrDefault(p => p.Id == bookDetail.Id);
            if(bookDetail !=null)
            {
                try
                {
                    _db.BookDetails.UpdateRange(bookDetail);
                   // _db.Entry(bookDetail).State = EntityState.Detached;
                    //_db.BookDetails.Attach(bookDetail);
                    //_db.Entry(bookDetail).State = EntityState.Modified;
                 // var state =  _db.ChangeTracker.Entries().ToString();
                if(_db.Entry(bookDetail).State == EntityState.Modified)
                {
                    _db.SaveChanges();
                } 
                   // return true;

                }

                catch(Exception ex)
                {
                    throw;
                }
               
            
            }
            return true;
        }
    }

}