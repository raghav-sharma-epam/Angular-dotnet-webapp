using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasKey(p=>p.Id);

            //one to many 
            // modelBuilder.Entity<BookDetail>().HasOne<Product>(p=>p.ProductRef).WithMany
            //(p=>p.BookDetailRef).HasForeignKey(f=>f.ProductId).
            //OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookDetail>().HasOne<BrandDetail>(p=>p.BrandDetail).WithMany
            (p=>p.BookDetails).HasForeignKey(f=>f.BrandId).OnDelete(DeleteBehavior.NoAction);

            


            //one to many relationship
            // modelBuilder.Entity<BookDetail>().HasOne(p =>p.ProductNav)
            // .WithMany
            // (p =>p.bookdetail).HasForeignKey(p=>p.ProdId);
            modelBuilder.Entity<LoginDto>().HasNoKey();
            modelBuilder.Entity<RegisterDto>().HasNoKey();

            // modelBuilder.Entity<AppUser>().HasOne(p=>p.ProductRef).
            // WithOne
            // (p=>p.AppUserRef).HasForeignKey(p=>p.)

            // modelBuilder.Entity<AppUser>().HasOne<Product>(p=>p.ProductRef).WithMany
            // (p=>p.AppUserRef).HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }
        
        public DbSet<MobileDetail> MobileDetails{get;set;}

        public DbSet<BrandDetail> BrandDetail{get;set;}

      

        public DbSet<AppUser> Users { get; set; }


        public DbSet<BlogImage> BlogImages { get; set; }

    }
}