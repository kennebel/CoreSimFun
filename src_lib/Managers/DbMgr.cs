using System.Collections.Generic;
using src_lib.Models;

namespace src_lib
{
    public partial class DbMgr : IDbMgr
    {
        protected ISimRepository Repository { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        public DbMgr(ISimRepository repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }
    }
}