namespace UniversityApp.BLL.Services
{
    public class FacultyService(IRepository<Faculty> repository, IUnitOfWork unitOfWork) : IFacultyService
    {
        public async Task<FacultyDto> AddFacultyAsync(FacultyCreateDto facultyCreate)
        {
            if (facultyCreate == null)
                throw new ArgumentNullException("This Argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var faculty = await repository.FirstOrDefaultAsync(x => x.Name == facultyCreate.Name && x.UniversityId == facultyCreate.UniversityId);
                if (faculty != null)
                    throw new InvalidOperationException("Same arguments can't be exist");
                var university = await unitOfWork.Universities.GetEntityByIdAsync(facultyCreate.UniversityId);
                if (university is null)
                    throw new InvalidOperationException("Argument doesn't exist");
                if (!university.IsFacultyTypeAllowed(facultyCreate.FacultyType))
                    throw new InvalidOperationException("This arguments don't match each others");
                var facultyEn = FacultyMapper.FacultyCrateDto(facultyCreate);
                await repository.AddEntityAsync(facultyEn);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
                return FacultyMapper.FacultyDto(facultyEn);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }

        }

        public async Task DeleteFacultyAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var faculty = await repository.GetEntityByIdAsync(id);
                if (faculty is null)
                    throw new ArgumentNullException("This argument doesn't exist");
                if (faculty.Students.Any())
                    throw new InvalidOperationException("This argument can't be deleted");
                await repository.DeleteEntity(faculty.Id);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<FacultyDto>> GetAllFacultiesAsync()
        {
            var faculties = await repository.GetAllEntitiesAsync();
            var returnFac = faculties.Select(x => FacultyMapper.FacultyDto(x)).ToList();
            return returnFac;
        }

        public async Task<FacultyDto> GetFacultyByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is mull");
            var faculty = await repository.GetEntityByIdAsync(id);
            if (faculty is null)
                throw new ArgumentNullException("This argument doesn't exits");
            return FacultyMapper.FacultyDto(faculty);
        }

        public async Task<FacultyDto> UpdateFaculty(Guid id, FacultyUpdateDto facultyUpdate)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var faculty = await repository.GetEntityByIdAsync(id);
                if (faculty is null)
                    throw new ArgumentNullException("This argument doesn't exist");
                if (faculty.Name == facultyUpdate.Name && faculty.FacultyType == facultyUpdate.FacultyType)
                    throw new InvalidOperationException("Updated entities can't be same");
                var existDean = await repository.FirstOrDefaultAsync(x => x.DeanName == facultyUpdate.DeanName && x.Id != id);
                if (existDean != null)
                    throw new InvalidOperationException("This argument already exist");
                faculty.UpdateName(facultyUpdate.Name);
                faculty.UpdateDeanName(facultyUpdate.DeanName);
                faculty.UpdateFacultyType(facultyUpdate.FacultyType);
                repository.UpdateEntity(faculty);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
                return FacultyMapper.FacultyDto(faculty);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
