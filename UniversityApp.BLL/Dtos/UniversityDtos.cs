namespace UniversityApp.BLL.Dtos
{
    public record UniversityDto(Guid Id,string Name,UniversityType UniversityType);
    public record UniversityCreateDto(string Name,UniversityType UniversityType);
    public record UniversityUpdateDto(Guid Id,string Name,UniversityType UniversityType);
}


