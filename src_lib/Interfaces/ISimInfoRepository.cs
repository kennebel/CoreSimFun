using src_lib.Models;

namespace src_lib
{
    public interface ISimInfoRepository
    {
        SimInfo GetSimInfo();
        SimInfo UpsertSimInfo(SimInfo si);
        bool RemoveSimInfo(SimInfo si);
    }
}