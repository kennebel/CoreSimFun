using src_lib.Models;

namespace src_lib
{
    public interface ISimRepository
    {
        #region SimInfo
        SimInfo GetSimInfo();
        SimInfo UpsertSimInfo(SimInfo si);
        bool RemoveSimInfo(SimInfo si);
        #endregion

        #region SimEvent
        SimEvent GetSimEvent(int id);

        SimEvent UpsertSimEvent(SimEvent se);
        #endregion
    }
}