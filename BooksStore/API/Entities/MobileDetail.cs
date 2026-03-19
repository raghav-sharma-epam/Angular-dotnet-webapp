using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class MobileDetail
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string  Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}