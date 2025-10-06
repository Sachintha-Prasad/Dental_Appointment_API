namespace Dental.Application.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
