namespace UniversityApp.CORE.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<University> Universities { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Student> Students { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}




