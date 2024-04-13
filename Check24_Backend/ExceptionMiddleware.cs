using Check24.Core;
using System.Net;

namespace Check24.Api
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) { 
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException e)
            {
                await HandleCustomExceptionAsync(httpContext, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }
        public async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
            await httpContext.Response.WriteAsync(e.Message);
        }

        public async Task HandleCustomExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            // custom known error code
            httpContext.Response.StatusCode = 505; 
            await httpContext.Response.WriteAsync(e.Message);
        }
    }

}
