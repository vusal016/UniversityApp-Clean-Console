namespace UniversityApp.CORE.Entities
{
    public class Faculty:BaseEntity
    {
        public Faculty()
        {
            
        }
        public Faculty(string name, string deanName, FacultyType facultyType, Guid universityId)
        {
            Name = name;
            DeanName = deanName;
            FacultyType = facultyType;
            UniversityId = universityId;
        }
        public string Name { get;private set; }
        public string DeanName { get;private set; }
        public FacultyType FacultyType { get;private set; }
        public List<Student> Students { get;private set; } = new();
        public University University { get;private set; }
        public Guid UniversityId{ get;private set; }

        public void UpdateName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException("This argument can't be null");
            this.Name = Name;
        }
        public void UpdateDeanName(string DeanName)
        {
            if (string.IsNullOrWhiteSpace(DeanName))
                throw new ArgumentNullException("This argument can't be null");
            this.DeanName = DeanName;
        }
        public void UpdateFacultyType(FacultyType facultyType)
        {
            if(!Enum.IsDefined(typeof(FacultyType),facultyType))
                throw new InvalidOperationException("This isn't correct variant");
            this.FacultyType = facultyType;
        }
    }
}
