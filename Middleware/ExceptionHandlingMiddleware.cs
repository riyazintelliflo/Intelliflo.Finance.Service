using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace Intelliflo.Finance.Service.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string error = "An error occurred while processing the request.";
                Log.Error($"Something went wrong: {ex}");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = new
                {
                    error = error,
                    details = ex.Message
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));

            }
        }
    }
}
