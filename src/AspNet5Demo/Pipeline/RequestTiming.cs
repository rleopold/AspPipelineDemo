using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace AspNetDemo.Pipeline
{
    public class RequestTiming
    {
        RequestDelegate _next;

        public RequestTiming(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnSendingHeaders((state) =>
            {
                var sw = state as Stopwatch;
                sw.Stop();
                context
                    .Response
                    .Headers
                    .Append("X-Api-Timing", $"{sw.ElapsedMilliseconds} ms"); //c# 6 string interop newness

            }, Stopwatch.StartNew());

            await _next(context);

        }
    }
}
