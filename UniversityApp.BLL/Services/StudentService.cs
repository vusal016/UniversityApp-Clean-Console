namespace UniversityApp.BLL.Services
{
    public class StudentService(IRepository<Student> repository, IUnitOfWork unitOfWork) : IStudentService
    {
        public async Task<StudentDto> AddStudentAsync(StudentCreateDto studentCreate)
        {
            if (studentCreate == null)
                throw new ArgumentNullException("This argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                if (studentCreate.Age < 18 || studentCreate.Age > 100)
                    throw new InvalidOperationException("This argument can't be ");
                if (studentCreate.Point < 0 && studentCreate.Point > 100)
                    throw new InvalidOperationException("This argument can't be ");
                var student = StudentMapper.StudentCreateDto(studentCreate);
                await repository.AddEntityAsync(student);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
                return StudentMapper.StudentDto(student);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var student = await repository.GetEntityByIdAsync(id);
                if (student is null)
                    throw new ArgumentNullException("This argument is null");
                await repository.DeleteEntity(student.Id);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }

        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            var students = await repository.GetAllEntitiesAsync();
            var returnStu = students.Select(x => StudentMapper.StudentDto(x)).ToList();
            return returnStu;
        }

        public async Task<StudentDto> GetStudentByIdAsunc(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is null");
            var student = await repository.GetEntityByIdAsync(id);
            if (student is null)
                throw new ArgumentNullException("This argument is null");
            return StudentMapper.StudentDto(student);
        }

        public async Task<StudentDto> UpdateStudentAsync(Guid id, StudentUpdateDto studentUpdate)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var student = await repository.GetEntityByIdAsync(id);
                if (student is null)
                    throw new ArgumentNullException("This argument doesn't exist");
                if (student.FullName == studentUpdate.FullName && student.Age == studentUpdate.Age && student.Point == studentUpdate.Point)
                    return StudentMapper.StudentDto(student);
                student.UpdateFullName(studentUpdate.FullName);
                student.UpdateAge(studentUpdate.Age);
                student.AddStudentPoint(student.Point);
                repository.UpdateEntity(student);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
                return StudentMapper.StudentDto(student);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}