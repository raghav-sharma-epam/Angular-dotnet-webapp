using API.Controllers.Interface;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "BlogImage")]
    public class BlogImageController : ControllerBase
    {

        private readonly IBlogImage blogImagerepo;
        public BlogImageController(IBlogImage blogimagerepo)
        {
            this.blogImagerepo = blogimagerepo;
        }


        [HttpPost]
        [Route("GetImageUpload")]
        public async Task<IActionResult> GetImageUpload([FromForm] BlogImageUploadDto dto)
        {
            if (dto?.File == null || ValidateFileUpload(dto.File) == false)
            {
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                var blogimage = new BlogImage()
                {
                    FileName = dto.FileName,
                    FileExtension = (Path.GetExtension(dto.File.FileName).ToLower()),
                    Title = dto.Title,
                    DateCreated = DateTime.Now
                };

                blogimage = await blogImagerepo.Upload(dto.File, blogimage);

                // If repository returns a relative Url (e.g. "/images/xxx.jpg"),
                // make it absolute for client consumption:
                var absoluteUrl = blogimage.Url;
                if (!string.IsNullOrWhiteSpace(absoluteUrl) && !absoluteUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    absoluteUrl = $"{Request.Scheme}://{Request.Host}{(absoluteUrl.StartsWith("/") ? "" : "/")}{absoluteUrl}";
                }

                var blogimageresponse = new BlogImage()
                {
                    FileExtension = blogimage.FileExtension,
                    Title = blogimage.Title,
                    DateCreated = blogimage.DateCreated,
                    FileName = blogimage.FileName,
                    Url = absoluteUrl
                };

                return Ok(blogimageresponse);
            }

            return BadRequest(ModelState);
        }

        private bool ValidateFileUpload(IFormFile file)
        {
            var allowedextension = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedextension.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        [Route("GetImages")]
        public async Task<List<BlogImageDto>> GetImages()
        {
            var data = await blogImagerepo.GetAllImages();
            var res = new List<BlogImageDto>();
            foreach (var item in data)
            {
                res.Add(new BlogImageDto()
                {
                    fileName = item.FileName,
                    Url = item.Url,
                    Title = item.Title,
                    DateCreated = item.DateCreated,
                });
            }

            return res;
        }
    }


}
