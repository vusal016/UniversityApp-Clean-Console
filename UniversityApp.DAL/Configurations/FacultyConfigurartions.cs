
namespace UniversityApp.DAL.Configurations
{
    public class FacultyConfigurartions : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.DeanName).HasMaxLength(25).IsRequired();
            builder.HasMany(x => x.Students)
                .WithOne(x => x.Faculty)
                .HasForeignKey(x => x.FacultyId);
        }
    }
}
