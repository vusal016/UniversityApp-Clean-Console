namespace UniversityApp.CORE.Entities
{
    public class University:BaseEntity
    {
        public University()
        {
            
        }
        public University(string name, UniversityType universityType)
        {
            Name = name;
            UniversityType = universityType;
        }

        public string Name { get;private set; }
        public UniversityType UniversityType { get;private set; }
        public List<Faculty> Faculties { get;private set; } = new List<Faculty>();
        public void UpdateName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
                throw new InvalidOperationException("This argument can't be null");
            this.Name=Name;
        }
        public void UpdateType(UniversityType type)
        {
            if (!Enum.IsDefined(typeof(UniversityType), type))
                throw new InvalidOperationException("This isn't correct variant");
            this.UniversityType = type;
        }
        public bool IsFacultyTypeAllowed(FacultyType facultyType)
        {
            if (!Enum.IsDefined(typeof(FacultyType), facultyType))
                throw new InvalidOperationException("This isn't correct variant");
            return this.UniversityType switch
            {
                UniversityType.Technical => facultyType == FacultyType.Science || facultyType == FacultyType.Engineering,
                UniversityType.Medical => facultyType == FacultyType.Science,
                UniversityType.Classical => facultyType == FacultyType.Science || facultyType == FacultyType.Humanitarian || facultyType == FacultyType.Engineering,
                UniversityType.Arts => facultyType == FacultyType.Humanitarian,
                UniversityType.Specialized => facultyType == FacultyType.Humanitarian || facultyType == FacultyType.Engineering || facultyType == FacultyType.Science
            };
        }
    }
}
