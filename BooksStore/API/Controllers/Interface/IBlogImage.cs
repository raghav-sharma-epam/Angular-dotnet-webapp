using API.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Interface
{
    public interface IBlogImage
    {
      Task<BlogImage> Upload(IFormFile file, BlogImage blogimage);
       Task <List<BlogImage>> GetAllImages();
    }
}
