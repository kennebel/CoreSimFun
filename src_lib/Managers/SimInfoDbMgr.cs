using System;
using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public partial class DbMgr
    {
        public SimInfo GetSimInfo()
        {
            var Result = SimInfos.GetSimInfo();
            if (Result == null) { Result = new SimInfo(); }
            return Result;
        }

        public bool UpsertSimInfo(SimInfo save)
        {
            SimInfos.UpsertSimInfo(save);

            return (UnitOfWork.Commit() > 0);
        }

        public bool RemoveSimInfo(SimInfo si)
        {
            SimInfos.RemoveSimInfo(si);

            return (UnitOfWork.Commit() > 0);
        }
    }
}