namespace UniversityApp.BLL.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyDto> AddFacultyAsync(FacultyCreateDto facultyCreate);
        Task<List<FacultyDto>> GetAllFacultiesAsync();
        Task<FacultyDto> GetFacultyByIdAsync(Guid id);
        Task<FacultyDto> UpdateFaculty(Guid id,FacultyUpdateDto facultyUpdate);
        Task DeleteFacultyAsync(Guid id);
    }
}
