using System;
using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public class SimInfoDbMgr
    {
        protected ISimInfoRepository Repository { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        public SimInfoDbMgr(ISimInfoRepository repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public SimInfo GetSimInfo()
        {
            var Result = Repository.Get();
            if (Result == null) { Result = new SimInfo(); }
            return Result;
        }

        public bool SaveSimInfo(SimInfo save)
        {
            Repository.Upsert(save);

            return (UnitOfWork.Commit() > 0);
        }
    }
}