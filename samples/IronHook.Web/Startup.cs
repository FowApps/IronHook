using IronHook.PostgreSql.Extensions;
using IronHook.Web.Context;
using MarkdownDocumenting.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IronHook.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddIronHook(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"));
            });

            services.AddDbContext<SampleDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"));
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("IronHook", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Iron Hook",
                    Version = "1.0.0",
                    Description = "This repo provides easily management hook operations of for dotnet application.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "furkan.dvlp@gmail.com",
                        Url = new Uri("https://github.com/FowApps/IronHook")
                    }
                });
                var docFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, docFile);

                if (File.Exists((filePath)))
                {
                    options.IncludeXmlComments(filePath);
                }
                options.DescribeAllParametersInCamelCase();
            });

            services.AddDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIronHook();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.EnableDeepLinking();
                options.ShowExtensions();
                options.DisplayRequestDuration();
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.RoutePrefix = "api-docs";
                options.SwaggerEndpoint("/swagger/IronHook/swagger.json", "IronHookSwagger");
            });
            app.UseDocumentation(opts => this.Configuration.Bind("DocumentationOptions", opts));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
