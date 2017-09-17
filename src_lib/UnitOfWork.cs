namespace src_lib
{
    public class UnitOfWork : IUnitOfWork
    {
        protected SimDbContext Context { get; set; }

        public UnitOfWork(SimDbContext context)
        {
            Context = context;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}