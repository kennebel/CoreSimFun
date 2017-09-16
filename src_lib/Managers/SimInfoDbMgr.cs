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
            using (var context = new SimDbContext())
            {
                if (save.Id == 0) { context.SimInfos.Add(save); }
                else { context.SimInfos.Update(save); }

                return (context.SaveChanges() == 1);
            }
        }

        public SimInfo GetSimInfo()
        {
            using (var context = new SimDbContext())
            {
                var Result = context.SimInfos.FirstOrDefault();
                if (Result == null) { Result = new SimInfo(); }
                return Result;
            }
        }
    }
}