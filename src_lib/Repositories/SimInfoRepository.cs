using src_lib.Models;

namespace src_lib
{
    public interface ISimInfoRepository
    {
        SimInfo Upsert(SimInfo si);

        bool Remove(SimInfo si);
        bool Remove(int id);
    }

    public class SimInfoRepository : ISimInfoRepository
    {
        protected SimDbContext DB { get; set; }

        public SimInfoRepository(SimDbContext db = null)
        {
            DB = db ?? new SimDbContext();
        }

        public SimInfo Upsert(SimInfo si)
        {
            if (si.Id == 0) { DB.SimInfos.Add(si); }
            else { DB.SimInfos.Update(si); }

            return null;
        }

        bool Remove(SimInfo si)
        {
            return Remove(si.Id);
        }

        bool Remove(int id)
        {
            
            return false;
        }
    }
}