using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BaiTap_02_23WebC_Nhom10.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ProductMiddlewarecs
    {
        private readonly RequestDelegate _next;

        public ProductMiddlewarecs(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ProductMiddlewarecsExtensions
    {
        public static IApplicationBuilder UseProductMiddlewarecs(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProductMiddlewarecs>();
        }
    }
}
