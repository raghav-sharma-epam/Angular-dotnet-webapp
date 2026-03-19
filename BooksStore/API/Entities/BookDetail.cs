using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Entities
{
    public class BookDetail
    {
        
        public int Id { get; set; }
       
        public string Name { get; set; }

        public string Description { get; set; }
       
        public double Price { get; set; }
         
        public string Genre{get; set;}

        //public string Picture { get; set; }
        
        public virtual Product ProductRef { get; set; } 

        public int ProductId { get; set; } 

        public int BrandId { get; set; }    

        public BrandDetail BrandDetail { get; set; }

        //public Product Product { get; set; }

      
        
        
        
        
        
        
    }
}