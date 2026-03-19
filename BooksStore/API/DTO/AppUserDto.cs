using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string  userName { get; set; }
      

        public string  Gender { get; set; } 
        public string Introduction { get; set; }    
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateofBirth { get; set; }

        public DateTime LastActive { get; set; }=DateTime.UtcNow;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        
        public List<PhotoDto> Photos { get; set; }= new List<PhotoDto>();
        [ForeignKeyAttribute("PhotoDto")]
        public int PhotoId { get; set; }

    }
}