namespace src_lib.Interfaces
{
    public interface IUnitOfWork
    {
         void Commit();
         void Rollback();
    }
}