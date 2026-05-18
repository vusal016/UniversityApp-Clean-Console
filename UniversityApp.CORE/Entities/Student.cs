    namespace UniversityApp.CORE.Entities
{
    public class Student : BaseEntity
    {
        public Student()
        {

        }
        public Student(string fullName, int age, int point, Guid facultyId)
        {
            FullName = fullName;
            Age = age;
            Point = point;
            FacultyId = facultyId;
        }
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public int Point { get; private set; }
        public Faculty Faculty { get; private set; }
        public Guid FacultyId { get; private set; }

        public void AddStudentPoint(int point)
        {
            if (point <0&&point > 100)
                throw new InvalidOperationException("This argument doesn't match request");
            this.Point=point;
        }
        public void UpdateFullName(string FullName)
        {
            if (string.IsNullOrWhiteSpace(FullName))
                throw new ArgumentNullException("This argument is null");
            this.FullName = FullName;
        }
        public void UpdateAge(int Age)
        {
            if(Age<18&&Age>100)
                throw new InvalidOperationException("This argument doesn't match request");
            this.Age = Age;
        }
    }
}
