﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using src_lib;

namespace src_web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //Add DB services
            string PathToDb = SimDbContext.FindDbFolder(Configuration.GetSection("Database").GetValue<string>("DbPath")) + System.IO.Path.DirectorySeparatorChar + "CoreSimFun.db";
            services.AddDbContext<SimDbContext>(options => options.UseSqlite("Data Source=" + PathToDb));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbMgr, DbMgr>();

            // Repositories
            services.AddScoped<ISimInfoRepository, SimInfoRepository>();
            services.AddScoped<ISimEventRepository, SimEventRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Database
            var DB = new SimDbContext(app.ApplicationServices.GetRequiredService<DbContextOptions<SimDbContext>>());
            DB.EnsureCreated(app.ApplicationServices);
            DB.DbInitialize(app.ApplicationServices);
        }
    }
}
