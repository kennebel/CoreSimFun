﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src_lib;
using src_lib.Models;

namespace src_sim
{
    class Program
    {
        #region Fields
        private static readonly IServiceProvider serviceProvider;
        #endregion

        #region Properties
        public static IConfigurationRoot Configuration { get; }

        public static ISimDbContext DB { get; set; }
        #endregion

        static Program()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            Configure();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            string PathToDb = SimDbContext.FindDbFolder(Configuration.GetSection("Database").GetValue<string>("DbPath")) + System.IO.Path.DirectorySeparatorChar + "CoreSimFun.db";
            Console.WriteLine("PathToDb: " + PathToDb);
            services.AddDbContext<SimDbContext>(options =>options.UseSqlite("Data Source=" + PathToDb));
        }

        private static void Configure()
        {
            // Database
            DB = new SimDbContext(serviceProvider.GetRequiredService<DbContextOptions<SimDbContext>>());
            DB.EnsureCreated(serviceProvider);
            DB.DbInitialize(serviceProvider);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello There~");

            DbMgr.LogSimEvent(SimEvent.Event.StartUp);

            SimInfo.instance.TickCount++;
            SimInfo.Save();

            DbMgr.LogSimEvent(SimEvent.Event.ShutDown);
        }
    }
}
