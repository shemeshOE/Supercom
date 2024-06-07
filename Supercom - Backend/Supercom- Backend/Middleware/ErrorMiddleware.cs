using Newtonsoft.Json;
using Supercom__Backend.Exceptions;
using System.Net;

namespace Supercom__Backend.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json"; // Set content type to JSON
                var response = JsonConvert.SerializeObject(new { error = ex.Message }); // Include exception message in JSON response
                await context.Response.WriteAsync(response);
            }
        }
    }
}
