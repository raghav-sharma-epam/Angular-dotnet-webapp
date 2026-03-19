using API.Controllers.Interface;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Repository
{
    public class BlogImageRepo : IBlogImage
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpcontext;
        private readonly StoreContext database;

        public BlogImageRepo(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpcontext, StoreContext 
            database)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpcontext = httpcontext;
            this.database = database;
        }

        public Task<List<BlogImage>> GetAllImages()
        {
            string imagesPath = Path.Combine(webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(imagesPath))
                return Task.FromResult(new List<BlogImage>()); // Return empty list if folder not found

            var imageFiles = Directory.GetFiles(imagesPath)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                .Select(f => Path.GetFileName(f))
                .ToList();

            var request = httpcontext.HttpContext.Request;

            var blogImages = imageFiles.Select(fileName => new BlogImage
            {
                FileName = fileName,
                Url = $"{request.Scheme}://{request.Host}/images/{fileName}"
            }).ToList();

            return Task.FromResult(blogImages);
        }



        //public async Task<BlogImage> Upload(IFormFile file, Entities.BlogImage blogimage)
        //{
        //    //upload to images folder to store the path in db
        //    var localpath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",
        //        $"{blogimage.FileName}{blogimage.FileExtension}");
        //    using var stream = new FileStream(localpath, FileMode.Create);
        //    await file.CopyToAsync(stream);


        //    //2-ipdate the db
        //    var httprequest = httpcontext.HttpContext.Request;
        //    var urlpath = $"{httprequest.Scheme}://{httprequest.Host}{httprequest.PathBase}/Images/{blogimage.FileName}{blogimage.FileExtension}";
        //    blogimage.Url = urlpath;

        //   await database.BlogImages.AddAsync(blogimage);
        //   await database.SaveChangesAsync();
        //    return blogimage;




        //}

        public async Task<BlogImage> Upload(IFormFile file, BlogImage blogImage)
        {
            if (file == null || file.Length == 0) return blogImage;

            var imagesFolder = Path.Combine(webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            // Ensure unique filename or implement your naming strategy
            var safeFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName).ToLower()}";
            var fullPath = Path.Combine(imagesFolder, safeFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            blogImage.FileName = safeFileName;
            // Use a relative URL so the controller can convert to absolute if desired
            blogImage.Url = $"/images/{safeFileName}";

            // Persist blogImage to DB here if needed (not shown)

            return blogImage;
        }
    }
}
