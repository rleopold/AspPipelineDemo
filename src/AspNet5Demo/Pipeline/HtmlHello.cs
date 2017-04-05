using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

            context.Response.Headers.Append("Content-Length", response.Length.ToString());

            await context.Response.WriteAsync(response.ToString());

            await _next(context);
        }
    }
}
