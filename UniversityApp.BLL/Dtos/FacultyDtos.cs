namespace UniversityApp.BLL.Dtos
{
    public record FacultyDto(Guid Id,string Name,string DeanName,FacultyType FacultyType,Guid UniversityId);
    public record FacultyCreateDto(string Name,string DeanName,FacultyType FacultyType,Guid UniversityId);
    public record FacultyUpdateDto(Guid Id,string Name,string DeanName,FacultyType FacultyType,Guid UniversityId);
}
