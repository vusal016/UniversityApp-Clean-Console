namespace UniversityApp.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> AddStudentAsync(StudentCreateDto studentCreate);
        Task<StudentDto> GetStudentByIdAsunc(Guid id);
        Task<List<StudentDto>> GetAllStudents();
        Task<StudentDto> UpdateStudentAsync(Guid id,StudentUpdateDto studentUpdate);
        Task DeleteStudentAsync(Guid id);
    }
}
