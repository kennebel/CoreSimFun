using System;
using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public partial class DbMgr
    {
        public bool SaveSimInfo(SimInfo save)
        {
            if (save.Id == 0) { DB.SimInfos.Add(save); }
            else { DB.SimInfos.Update(save); }

            return (DB.SaveChanges() == 1);
        }

        public SimInfo GetSimInfo()
        {
            var Result = DB.SimInfos.FirstOrDefault();
            if (Result == null) { Result = new SimInfo(); }
            return Result;
        }
    }
}