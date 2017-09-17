using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public class SimInfoRepository : ISimInfoRepository
    {
        protected SimDbContext DB { get; set; }

        public SimInfoRepository(SimDbContext db)
        {
            DB = db ?? new SimDbContext();
        }

        public SimInfo Get()
        {
            return DB.SimInfos.FirstOrDefault();
        }

        public SimInfo Upsert(SimInfo si)
        {
            if (si.Id == 0) { DB.SimInfos.Add(si); }
            else { DB.SimInfos.Update(si); }

            return null;
        }

        public bool Remove(SimInfo si)
        {
            return DB.SimInfos.Remove(si) != null;
        }
    }
}