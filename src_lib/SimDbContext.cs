using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq.Expressions;
using src_lib.Models;
using System.IO;

namespace src_lib
{
    public class SimDbContext : DbContext
    {
        #region DbSets
        public DbSet<SimState> State { get; set; }
        #endregion
        
        #region Properties
        #endregion

        #region Construct / Destruct
        public SimDbContext (DbContextOptions<SimDbContext> options)
            : base(options)
        {
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
        #endregion
    }
}