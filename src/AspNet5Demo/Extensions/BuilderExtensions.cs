using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using AspNetDemo.Pipeline;

namespace AspNetDemo.Extensions
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseHtmlHello(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HtmlHello>();
        }

        public static IApplicationBuilder UseApiHello(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiHello>();
        }

        public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestTiming>();
        }
    }
}
