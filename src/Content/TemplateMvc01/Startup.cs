using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

namespace TemplateMvc01
{
    /// <summary>
    /// Web Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration">Injected</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Configuration. Public for test rigs
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services">Injected</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\TemplateMvc01.xml");
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TemplateMvc01API", Version = "v1" });
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">Injected</param>
        /// <param name="env">Injected</param>
        /// <param name="loggerFactory">Injected</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            #region Serilog
            
            loggerFactory.AddSerilog();
            app.UseSerilogRequestLogging();
            
            #endregion
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
            #region Swagger
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "TemplateMvc01 API v1"));

            #endregion
            
        }
    }
}
