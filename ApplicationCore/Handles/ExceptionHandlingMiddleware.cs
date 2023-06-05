using ApplicationCore.Constants;
using ApplicationCore.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using System.Net;
using System.Text.Json;

namespace ApplicationCore.Handles
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode == 404 && !httpContext.Response.HasStarted)
                {
                    throw new AggregateException(ContentManager.RouterNotFound);
                }   
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType =ContentManager.ContentType;

            var errorResponse = new ErrorResponse();
            switch (exception)
            {
                case ApplicationException ex:
                    if (ex.Message.Contains(ContentManager.InvalidToken))
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        errorResponse.statusCode = HttpStatusCode.Forbidden;
                        errorResponse.Message = ex.Message;
                        break;
                    }
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.statusCode = HttpStatusCode.BadRequest;
                    errorResponse.Message = ex.Message;
                    break;
                case AggregateException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.statusCode = HttpStatusCode.BadRequest;
                    errorResponse.Message = ex.Message;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.statusCode = HttpStatusCode.InternalServerError;
                    errorResponse.Message = ContentManager.InternalServerError;
                    break;
            }
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}
