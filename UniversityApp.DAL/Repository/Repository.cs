namespace UniversityApp.DAL.Repository
{
    public class Repository<T>(UniversityDbContext university): IRepository<T> where T : BaseEntity
    {
        public async Task AddEntityAsync(T entity)
        {
            await university.Set<T>().AddAsync(entity);
        }

        public async Task DeleteEntity(Guid id)
        {
            var entity = await university.Set<T>().FindAsync(id);
             university.Set<T>().Remove(entity);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await university.Set<T>().FirstOrDefaultAsync(predicate);
                
        }

        public async Task<List<T>> GetAllEntitiesAsync()
        {
            var list= await university.Set<T>().ToListAsync();
            return list;
        }

        public async Task<T> GetEntityByIdAsync(Guid id)
        {
            var entity = await university.Set<T>().FindAsync(id);
            return entity;
        }

        public T UpdateEntity(T entity)
        {
            var db = university.Set<T>().Update(entity);
            return db.Entity;
        }
    }
}


