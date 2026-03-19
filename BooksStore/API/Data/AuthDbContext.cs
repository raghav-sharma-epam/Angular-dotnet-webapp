

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Data
{
    public class AuthDbContext :IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // way to seed data from EF core itself as this method will be called on migration
            var data = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "1",
                    ConcurrencyStamp = "Random",
                    Name = "Reader",
                    NormalizedName = "ReaderRole",
                },
                  new IdentityRole()
                {
                    Id = "2",
                    ConcurrencyStamp = "Random",
                    Name = "Writer",
                    NormalizedName = "WriterRole",
                }
            };
            builder.Entity<IdentityRole>().HasData(data);
        }
    }
}
