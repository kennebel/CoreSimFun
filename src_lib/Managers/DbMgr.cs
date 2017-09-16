using System.Collections.Generic;
using src_lib.Models;

namespace src_lib
{
    public partial class DbMgr : IDbMgr
    {
        protected SimDbContext DB { get; set; }

        public DbMgr(SimDbContext db)
        {
            DB = db;
        }
    }
}