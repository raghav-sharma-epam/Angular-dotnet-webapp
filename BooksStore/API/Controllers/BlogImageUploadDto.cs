using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    public class BlogImageUploadDto
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
    }
}