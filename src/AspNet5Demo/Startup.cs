using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AspNetDemo.Extensions;

namespace AspNetDemo
{
    public class Startup
    {
        bool IsTimingOn = true; // we would want this to be config, but that's another demo!
        
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
