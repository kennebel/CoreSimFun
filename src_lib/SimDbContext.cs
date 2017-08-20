using Microsoft.EntityFrameworkCore;
using src_lib.Models;

namespace src_lib
{
    public class SimDbContext : DbContext
    {
        #region DbSets
        public DbSet<SimState> State { get; set; }
        #endregion
        
        #region Properties
        private string ConnectionString{ get; set; }
        #endregion

        #region Construct / Destruct
        public SimDbContext (DbContextOptions<SimDbContext> options, string connectionString = null)
            : base(options)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseSqlite(ConnectionString);
            }
        }
        #endregion
    }
}