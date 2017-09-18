namespace src_lib
{
    public interface IUnitOfWork
    {
         int Commit();
         void Rollback();

         bool BatchStart();
         bool BatchFinish();
    }
}