using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using src_lib;

namespace src_sim
{
    class Program
    {
        private static readonly IServiceProvider serviceProvider;

        static Program()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            string PathToDb = SimDbContext.FindDbFolder("SharedDb") + System.IO.Path.DirectorySeparatorChar + "CoreSimFun.db";
            Console.WriteLine("PathToDb: " + PathToDb);
            services.AddDbContext<SimDbContext>(options =>options.UseSqlite("Data Source=" + PathToDb));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello There~");

            //var Context = new SimDbContext("");
        }
    }
}
