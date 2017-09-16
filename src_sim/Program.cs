using System;
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

        public static DbMgr DB { get; set; }
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
            var context = new SimDbContext(serviceProvider.GetRequiredService<DbContextOptions<SimDbContext>>());
            context.EnsureCreated(serviceProvider);
            context.DbInitialize(serviceProvider);

            DB = new DbMgr(context);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello There~");

            DB.LogSimEvent(SimEvent.Event.StartUp);

            var si = DB.GetSimInfo();
            si.TickCount++;
            DB.SaveSimInfo(si);

            DB.LogSimEvent(SimEvent.Event.ShutDown);
        }
    }
}
