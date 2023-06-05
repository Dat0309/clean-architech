using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ApplicationCore.Wrappers
{
    public class Response<T> : IActionResult
    {
        public Response() { }

        /// <summary>
        /// Constructer of OK Response or similar
        /// </summary>
        /// <param name="data"> Data to display in Response body </param>
        /// <param name="statusCode"> Status code of response </param>
        /// <param name="msg"> Message of response </param>
        /// <param name="succeeded"> Status of response </param>
        public Response(T data, HttpStatusCode statusCode, string msg)
        {
            this.statusCode = statusCode;
            this.Succeeded = true;
            this.Message = msg;
            this.Data = data ?? default(T);
            currentDate = DateTime.Now;
        }

        public Response(HttpStatusCode statudCode, string msg)
        {
            this.statusCode = statusCode;
            this.Succeeded = true;
            this.Message = msg;
            this.Data = default(T);
            currentDate = DateTime.Now;
        }

        public HttpStatusCode statusCode { get; set; }
        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public DateTime currentDate { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            await response.WriteAsync(JsonSerializer.Serialize(Data));
        }
    }
}
