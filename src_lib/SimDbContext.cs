using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq.Expressions;
using src_lib.Models;
using System.IO;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace src_lib
{
    public class SimDbContext : DbContext
    {
        #region DbSets
        public DbSet<SimEvent> SimEvents { get; set; }
        public DbSet<SimInfo> SimInfos { get; set; }
        #endregion

        #region Properties
        public static DbContextOptions<SimDbContext> Options{ get; set; }
        #endregion

        #region Construct / Destruct
        public SimDbContext() : base(Options) { }

        public SimDbContext(DbContextOptions<SimDbContext> options)
            : base(options)
        {
            Options = options;
        }
        #endregion

        #region Methods
        public static string FindDbFolder(string name = null)
        {
            if (!string.IsNullOrEmpty(name))
            {
                DirectoryInfo DI;
                DirectoryInfo[] SubFolders;
                string BaseLocation = "";
                string Location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                while (!Location.EndsWith(name))
                {
                    DI = new DirectoryInfo(Location);
                    SubFolders = DI.GetDirectories();
                    foreach (var SubFolder in SubFolders)
                    {
                        if (SubFolder.Name == name)
                        {
                            return SubFolder.FullName;
                        }
                    }

                    if (DI.Parent != null)
                    {
                        BaseLocation = DI.Parent.FullName;
                        if (BaseLocation == Location) { break; }
                        Location = BaseLocation;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new SimDbContext(serviceProvider.GetRequiredService<DbContextOptions<SimDbContext>>());
            context.Database.EnsureCreated();
        }

        public static void DbInitialize(IServiceProvider serviceProvider)
        {
            using (var context = new SimDbContext(serviceProvider.GetRequiredService<DbContextOptions<SimDbContext>>()))
            {
                if (context.SimEvents.Any())
                {
                    return;   // DB has been seeded
                }

                // Otherwise initialize!
            }
        }
        #endregion
    }
}