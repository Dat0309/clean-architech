using ApplicationCore.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApplicationCore.Wrappers
{
    public class ErrorResponse : IActionResult
    {
        public ErrorResponse() { }
        public ErrorResponse(string message, HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
            this.Message = message;
            this.currentDate = DateTime.Now;
            this.Succeeded = false;
        }
        public HttpStatusCode statusCode { get; set; }
        public string? Message { get; set; }
        public DateTime currentDate { get; set; }
        public bool Succeeded { get; set; }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var errResponse = context.HttpContext.Response;
            errResponse.ContentType = ContentManager.ContentType;
        }
    }
}
