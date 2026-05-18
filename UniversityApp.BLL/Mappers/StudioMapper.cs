namespace UniversityApp.BLL.Profiles
{
    public static class StudentMapper
    {
        public static Student StudentCreateDto(StudentCreateDto studentCreate)
        {
            return new Student(
                studentCreate.FullName,
                studentCreate.Age,
                studentCreate.Point,
                studentCreate.FacultyId
                );

        }
        public static StudentDto StudentDto(Student student)
        {
            return new StudentDto(
                student.Id,
                student.FullName,
                student.Age,
                student.Point,
                student.FacultyId
                );
        }
    }
}
