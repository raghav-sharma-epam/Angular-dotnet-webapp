using System.Net;

namespace API.DTO
{
    public class ExceptionResponse
    {
        public string StatusCode { get; set; }
        public string Description { get; set; }

        public ExceptionResponse(string statusCode,string description)
        {
            this.StatusCode = statusCode;
            this.Description = description;
        }
    }
}
