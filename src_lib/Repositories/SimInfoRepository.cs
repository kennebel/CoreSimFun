using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public class SimInfoRepository : ISimInfoRepository
    {
        #region Properties
        protected SimDbContext DB { get; set; }
        #endregion

        #region Construct / Destruct
        public SimInfoRepository(SimDbContext db)
        {
            DB = db ?? new SimDbContext();
        }
        #endregion

        #region Interface Methods
        public SimInfo GetSimInfo()
        {
            return DB.SimInfos.FirstOrDefault();
        }

        public SimInfo UpsertSimInfo(SimInfo si)
        {
            if (si.Id == 0) { DB.SimInfos.Add(si); }
            else { DB.SimInfos.Update(si); }

            return null;
        }

        public bool RemoveSimInfo(SimInfo si)
        {
            return DB.SimInfos.Remove(si) != null;
        }
        #endregion
    }
}