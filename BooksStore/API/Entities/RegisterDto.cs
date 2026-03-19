using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class RegisterDto
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string  password { get; set; }

        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string Interest { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime LastActive { get; set; }=DateTime.UtcNow;
        public DateTime DateCreated { get; set; }= DateTime.UtcNow;

        // public Photo Photo { get; set; }
        // public int PhotoId { get; set; }

        // public Product Product { get; set; }
        // public int ProductId { get; set; }

        // [Compare("password", ErrorMessage = "Password mismatch")]
        // [Required]
        // public string confirmPassword { get; set; }
    }
}