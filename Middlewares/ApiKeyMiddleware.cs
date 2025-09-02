namespace API_Cliente_con_EF.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_HEADER = "X-API-KEY"; // Nombre del header

        //  API Key  (en appsettings.json)
        private readonly string _apiKey;

        public ApiKeyMiddleware(RequestDelegate next, string apiKey)
        {
            _next = next;
            _apiKey = apiKey;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("API Key missing");
                return;
            }

            if (!string.Equals(extractedApiKey, _apiKey))
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            // Si pasa la validación, continúa con la siguiente etapa
            await _next(context);
        }
    }

}
