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
    public class ApiHello
    {
        RequestDelegate _next;
        public ApiHello(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Debug.WriteLine("api pipeline");
            var response = new StringBuilder();
            response.AppendLine("{");
            response.AppendLine("   \"id\": 1,");
            response.AppendLine("   \"description\": \"hello\",");
            response.AppendLine("   \"tags\": [\"hello\", \"world\"]");
            response.AppendLine("}");

            context.Response.Headers.Append("Content-Type", "application/json");
            await context.Response.WriteAsync(response.ToString());
            await _next(context);
        }
    }
}