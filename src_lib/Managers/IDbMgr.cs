using System.Collections.Generic;
using src_lib.Models;

namespace src_lib
{
    public interface IDbMgr
    {
         #region SimInfo
         bool SaveSimInfo(SimInfo save);
         SimInfo GetSimInfo();
         #endregion

         #region SimEvent
         bool LogSimEvent(SimEvent.Event eventType, string message = null);
         IEnumerable<SimEvent> RecentSimEvents(int recentCount=5);
         #endregion
    }

    public partial class DbMgr : IDbMgr
    {
        protected ISimDbContext DB { get; set; }

        public DbMgr(ISimDbContext db)
        {
            DB = db;
        }
    }
}