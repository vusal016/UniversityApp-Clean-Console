namespace UniversityApp.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<UniversityDto> AddUniversityAsync(UniversityCreateDto createDto);
        Task<UniversityDto> GetUniversityByIdAsyncAsync(Guid id);
        Task<List<UniversityDto>> GetAllUniversitiesAsync();
        Task DeleteUniversityAsync(Guid id);
        Task<UniversityDto> UpdateUniversityAsync(Guid id, UniversityUpdateDto universityUpdate);
        Task<List<UniversityDto>> SearchUniversityAsync(string value);
    }
}
