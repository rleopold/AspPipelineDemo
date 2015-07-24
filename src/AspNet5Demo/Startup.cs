using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using AspNetDemo.Extensions;

namespace AspNetDemo
{
    public class Startup
    {
        bool IsTimingOn = false; // we would want this to be config, but that's another demo!
        
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .MapWhen((context) => context.Request.Headers.ContainsKey("X-Request-Timing"), ConfigureTimedApi)
                .Map("/api", ConfigureApi)
                .Map("", ConfigureWeb);
        }

        public void ConfigureApi(IApplicationBuilder app)
        {
            app.UseApiHello();
        }

        public void ConfigureWeb(IApplicationBuilder app)
        {
            if (IsTimingOn)
                app.UseRequestTiming(); // we can add middleware based upon a configuration setting etc
            app.UseHtmlHello();
        }

        public void ConfigureTimedApi(IApplicationBuilder app)
        {
            app
                .UseRequestTiming()
                .UseApiHello();     // ...or we can actually create a unique pipeline path
        }

    }
}
