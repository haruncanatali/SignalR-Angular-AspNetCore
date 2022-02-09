using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecimAnaliz.API.Hubs;
using SecimAnaliz.API.Models;
using SecimAnaliz.API.Subscription;
using SecimAnaliz.API.Subscription.Middleware;

namespace SecimAnaliz.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => options.AddDefaultPolicy(policy =>
                policy.AllowCredentials().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(x => true)));
            services.AddSignalR();
            services.AddSingleton<DatabaseSubscription<TblParti>>();
            services.AddSingleton<DatabaseSubscription<TblOy>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseDatabaseSubscription<DatabaseSubscription<TblOy>>("Tbl_Oy");
            app.UseDatabaseSubscription<DatabaseSubscription<TblParti>>("Tbl_Parti");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<OyHub>("/oyhub");
            });
        }
    }
}
