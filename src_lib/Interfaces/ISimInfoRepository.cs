using src_lib.Models;

namespace src_lib
{
    public interface ISimInfoRepository
    {
        SimInfo Get();

        SimInfo Upsert(SimInfo si);

        bool Remove(SimInfo si);
    }
}