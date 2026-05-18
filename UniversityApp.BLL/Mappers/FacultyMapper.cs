    namespace UniversityApp.BLL.Profiles
{
    public static class FacultyMapper
    {
        public static Faculty FacultyCrateDto(FacultyCreateDto facultyCreateDto)
        {
            return new Faculty(
                facultyCreateDto.Name,
                facultyCreateDto.DeanName,
                facultyCreateDto.FacultyType,
                facultyCreateDto.UniversityId
                );
        }
        public static FacultyDto FacultyDto(Faculty faculty)
        {
            return new FacultyDto(
                faculty.Id,
                faculty.Name,
                faculty.DeanName,
                faculty.FacultyType,
                faculty.UniversityId
                );
                
        }
    }
}
