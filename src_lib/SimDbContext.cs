using Microsoft.EntityFrameworkCore;
using src_lib.Models;

namespace src_lib
{
    public class SimDbContext : DbContext
    {
        public SimDbContext (DbContextOptions<SimDbContext> options)
            : base(options)
        {
        }

        public DbSet<SimState> State { get; set; }
    }}