using System;

namespace API.DTO
{
    public class BlogImageDto
    {
        public string fileName { get; set; }
        public string FileExtension { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
