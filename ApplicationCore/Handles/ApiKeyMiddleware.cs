using ApplicationCore.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TitanWeb.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey = ContentManager.ApiKey;
        private const string _allowedApiKeysSection = ContentManager.AllowedApiKeys;
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(_apiKey, out
                    var extractedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync(ContentManager.RequiredApi);
                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var allowedApiKeyList = appSettings.GetSection(_allowedApiKeysSection).Get<List<string>>();
            var apiKey = extractedApiKey.FirstOrDefault();
            if (!allowedApiKeyList.Contains(apiKey!))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync(ContentManager.UnauthorizedWarning);
                return;
            }
            await _next(context);
        }
    }
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKey(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
