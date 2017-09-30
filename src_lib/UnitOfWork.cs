namespace src_lib
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        protected SimDbContext Context { get; set; }
        #endregion

        #region Construct / Destruct
        public UnitOfWork()
        {
            Context = new SimDbContext();
        }
        public UnitOfWork(SimDbContext context)
        {
            Context = context;
        }
        #endregion

        #region Interface Methods
        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }

        public bool BatchStart()
        {
            return false;
        }

        public bool BatchFinish()
        {
            return false;
        }
        #endregion
    }
}