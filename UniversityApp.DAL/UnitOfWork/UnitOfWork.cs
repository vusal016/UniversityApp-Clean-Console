    namespace UniversityApp.DAL.UnitOfWork
    {
        public class UnitOfWork: IUnitOfWork
        {
            private UniversityDbContext _universityDb;
            private IDbContextTransaction _transaction;

            public UnitOfWork(UniversityDbContext uniDb,IRepository<University> uNiversities, IRepository<Faculty> faculties, IRepository<Student> students)
            {
                _universityDb = uniDb;
                Universities = uNiversities;
                Faculties = faculties;
                Students = students;
            }

            public IRepository<University> Universities { get; }

            public IRepository<Faculty> Faculties { get; }

            public IRepository<Student> Students { get; }

            public async Task BeginTransactionAsync()
            {
                if (_transaction != null)
                    throw new InvalidOperationException("Transaction Already exist");
                 _transaction = await _universityDb.Database.BeginTransactionAsync();
            }

            public async Task CommitAsync()
            {
                if (_transaction is null)
                    throw new InvalidOperationException("There is no transaction to commit");
                try
                {
                    await _universityDb.SaveChangesAsync();
                    await _transaction.CommitAsync();
                }
                catch 
                {
                    await RollbackAsync();
                    throw;
                }
                finally
                {
                   await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }

            public async Task RollbackAsync()
            {
                if (_transaction == null)
                    return;
                try
                {
                    await _transaction.RollbackAsync();
                }
                finally
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }

            public async Task<int> SaveChangesAsync()
            {
               int affectedRows= await _universityDb.SaveChangesAsync();
                return affectedRows;
            }
        }
    }