using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Controllers.Interface
{
    public interface IBookDetail
    {
        public Task<List<BookDetail>> GetBookDetails();

        public Task<string>BookDetailAdd(BookDetail detail);

        //public Task<T> BookbyId(T id);

        public Task<BookDetail> BookbyId(int id);


        public bool Updatedata(BookDetail bookDetail);

        public bool DeleteBookDetail(int id);
    }
}