using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

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
            context.Response.OnStarting((state) =>
            {
                var sw = state as Stopwatch;
                sw.Stop();
                context
                    .Response
                    .Headers
                    .Append("X-Api-Timing", $"{sw.ElapsedMilliseconds} ms"); //c# 6 string interop newness
                return Task.CompletedTask;
            }, Stopwatch.StartNew());

            await _next(context);

        }
    }
}
