using System.Collections.Generic;
using src_lib.Models;

namespace src_lib
{
    public partial class DbMgr : IDbMgr
    {
        protected ISimInfoRepository SimInfos { get; set; }
        protected ISimEventRepository SimEvents { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        public DbMgr(IUnitOfWork unitOfWork, ISimInfoRepository simInfoRepository, ISimEventRepository simEventRepository)
        {
            UnitOfWork = unitOfWork;
            SimInfos = simInfoRepository;
            SimEvents = simEventRepository;
        }
    }
}