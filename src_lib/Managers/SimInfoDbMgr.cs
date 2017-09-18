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
            var Result = Repository.GetSimInfo();
            if (Result == null) { Result = new SimInfo(); }
            return Result;
        }

        public bool SaveSimInfo(SimInfo save)
        {
            Repository.UpsertSimInfo(save);

            return (UnitOfWork.Commit() > 0);
        }
    }
}