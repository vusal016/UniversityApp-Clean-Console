namespace UniversityApp.BLL.Dtos
{
    public record StudentDto(Guid Id,string FullName,int Age,int Point,Guid FacultyId);
    public record StudentCreateDto(string FullName,int Age,int Point,Guid FacultyId);
    public record StudentUpdateDto(Guid Id, string FullName, int Age, int Point, Guid FacultyId);
 
}
