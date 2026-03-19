using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class BrandDetail
    {
        public int Id { get; set; } 
        public string BrandName { get; set; }

        public List<BookDetail> BookDetails { get; set; }

    }
}