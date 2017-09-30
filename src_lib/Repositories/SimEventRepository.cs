using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public class SimEventRepository : ISimEventRepository
    {
        #region Properties
        protected SimDbContext DB { get; set; }
        #endregion

        #region Construct / Destruct
        public SimEventRepository(SimDbContext db)
        {
            DB = db ?? new SimDbContext();
        }
        #endregion

        #region Interface Methods
        public IQueryable<SimEvent> GetSimEvents()
        {
            return DB.SimEvents.AsQueryable();
        }
        
        public SimEvent GetSimEvent(int id)
        {
            throw new System.NotImplementedException();
        }

        public SimEvent UpsertSimEvent(SimEvent se)
        {
            throw new System.NotImplementedException();
        }

        public bool ClearAllEvents()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        /*
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
         */
    }
}