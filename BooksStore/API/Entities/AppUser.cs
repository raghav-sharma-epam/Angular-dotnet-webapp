using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string  userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }

        public string  Gender { get; set; } 
        public string Introduction { get; set; }    
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateofBirth { get; set; }

        public DateTime LastActive { get; set; }=DateTime.UtcNow;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        
        public List<Photo> Photos { get; set; }= new List<Photo>();
        [ForeignKeyAttribute("Photo")]
        public int PhotoId { get; set; }

        // public Product ProductRef { get; set; }

        // public int ProductId { get; set; }


       
    }
}