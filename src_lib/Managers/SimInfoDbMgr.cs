using System;
using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public static partial class DbMgr
    {
        public static bool SaveSimInfo(SimInfo save)
        {
            using (var context = new SimDbContext())
            {
                if (save.Id == 0) { context.SimInfos.Add(save); }
                else { context.SimInfos.Update(save); }

                return (context.SaveChanges() == 1);
            }
        }

        public static SimInfo GetSimInfo()
        {
            using (var context = new SimDbContext())
            {
                return context.SimInfos.FirstOrDefault();
            }
        }
    }
}