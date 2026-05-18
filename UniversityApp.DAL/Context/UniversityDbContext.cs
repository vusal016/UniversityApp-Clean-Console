namespace UniversityApp.DAL.Context
{
    public class UniversityDbContext:DbContext
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students  { get; set; }

        string connect = $"Server=(localdb)\\MSSQLLocalDB;Database=UniDb;Trusted_Connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connect);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
