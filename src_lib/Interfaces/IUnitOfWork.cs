namespace src_lib
{
    public interface IUnitOfWork
    {
         int Commit();
         void Rollback();
    }
}