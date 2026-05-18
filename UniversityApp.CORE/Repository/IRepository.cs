namespace UniversityApp.BLL.Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task AddEntityAsync(T entity);
        Task<T> GetEntityByIdAsync(Guid id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllEntitiesAsync();
         T UpdateEntity(T entity);
        Task DeleteEntity(Guid id);

    }
}


