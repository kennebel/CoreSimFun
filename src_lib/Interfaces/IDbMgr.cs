using System.Collections.Generic;
using src_lib.Models;

namespace src_lib
{
    public interface IDbMgr
    {
        #region SimInfo
        SimInfo GetSimInfo();
        bool SaveSimInfo(SimInfo save);
        #endregion

         #region SimEvent
         bool LogSimEvent(SimEvent.Event eventType, string message = null);
         IEnumerable<SimEvent> RecentSimEvents(int recentCount=5);
         #endregion
    }
}