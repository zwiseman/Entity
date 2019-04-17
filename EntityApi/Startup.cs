using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using EntityApi.Models;
using System.Web;

namespace EntityApi
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
            Console.WriteLine("Startup");
            Console.WriteLine("we are injecting cors policy");
            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => {
                        builder.WithOrigins("http://localhost:4200")
                            .WithOrigins("http://zwiseman.com.s3-website-us-east-1.amazonaws.com")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            Console.WriteLine("We are injecting mvc");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            Console.WriteLine("We are injecting a database context here");
            services.AddDbContext<EntityContext> (options => options.UseSqlServer(Configuration.GetConnectionString("TestDB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Console.WriteLine("We are adding the cors policy");
            app.UseCors("AllowSpecificOrigin");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            Console.WriteLine("We are adding MVC");
            app.UseMvc();
        }
    }
}
