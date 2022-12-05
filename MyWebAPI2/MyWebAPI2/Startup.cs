using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyWebAPI2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } 

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddTransient<CustomMiddleware1>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebAPI2", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebAPI2 v1"));
            //
            }

            //app.Use(async (context,next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Middleware Use Method 1 \n");
            //       next();
            //    await context.Response.WriteAsync("\n Hello from Middleware Use Method 1 second Message\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("\n Hello from Middleware Use Method 2 \n");
            //    next();
            //});

            //app.UseMiddleware<CustomMiddleware1>();

            //app.Map("/swapnil", CustomeCode);

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("\n Hello from Middleware Run Method 3 \n");
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void CustomeCode(IApplicationBuilder app)
        {
            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("\n Custome Middleware message 1 \n");
            });
        }
    }
}
