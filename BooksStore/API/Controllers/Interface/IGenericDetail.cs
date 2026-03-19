using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Interface
{
    public interface IGenericDetail<T> where T:class
    {
        List<T> GetDetail();

        Task<T> GetById(int id);
        string AddDetail(T data);
    }
}