
namespace UniversityApp.DAL.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Point).IsRequired();
        }
    }
}
