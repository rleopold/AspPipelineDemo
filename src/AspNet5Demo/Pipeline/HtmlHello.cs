using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace AspNetDemo.Pipeline
{
    public class HtmlHello
    {
        RequestDelegate _next;
        public HtmlHello(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var response = new StringBuilder();
            response.AppendLine("<!DOCTYPE html>");
            response.AppendLine("<html>");
            response.AppendLine("<head>");
            response.AppendLine("    <meta charset=\"utf - 8\" />");
            response.AppendLine("    <title>Hello World</title>");
            response.AppendLine("</head>");
            response.AppendLine("<body>");
            response.AppendLine(" <h1>Hello World!</h1>");
            response.AppendLine("</body>");
            response.AppendLine("</html>");

            await context.Response.WriteAsync(response.ToString());

            await _next(context);
        }
    }
}
