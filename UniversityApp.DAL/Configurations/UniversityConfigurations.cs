namespace UniversityApp.DAL.Configurations
{
    public class UniversityConfigurations : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.Faculties)
                .WithOne(x => x.University)
                .HasForeignKey(x => x.UniversityId);
        }
    }
}
