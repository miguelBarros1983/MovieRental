using System.Net;
using System.Text.Json;

namespace MovieRental.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ErrorHandlingMiddleware(RequestDelegate requestDelegate, IWebHostEnvironment webHostEnvironment)
        {
            _requestDelegate = requestDelegate;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context); // Continua o pipeline
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            // Define status code baseado no tipo de exceção (pode expandir)
            context.Response.StatusCode = ex switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                InvalidOperationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = new
            {
                Message = ex.Message,
                StackTrace = _webHostEnvironment.IsDevelopment() ? ex.StackTrace : null
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
