namespace UniversityApp.BLL.Services
{
    public class UniversityService(IRepository<University> repository, IUnitOfWork unitOfWork) : IUniversityService
    {
        public async Task<UniversityDto> AddUniversityAsync(UniversityCreateDto createDto)
        {
            if (createDto == null)
                throw new ArgumentNullException("Argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var entityUni = await repository.FirstOrDefaultAsync(x => x.Name == createDto.Name);
                if (entityUni != null)
                    throw new AlreadyExistexception("This Argument already exist");
                var university = UniversityMapper.CreateUniversityDto(createDto);
                await repository.AddEntityAsync(university);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
                return UniversityMapper.UniversityDto(university);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }

        }

        public async Task DeleteUniversityAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is null");
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var university = await repository.GetEntityByIdAsync(id);
                if (university is null)
                    throw new ArgumentNullException("This argument is null");
                if (university.Faculties.Any(x => x.Students.Any()))
                    throw new InvalidOperationException("This argument can't be deleted");
                await repository.DeleteEntity(university.Id);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<UniversityDto>> GetAllUniversitiesAsync()
        {
            var universities = await repository.GetAllEntitiesAsync();
            var returnUnis = universities.Select(x => UniversityMapper.UniversityDto(x)).ToList();
            return returnUnis;
        }

        public async Task<UniversityDto> GetUniversityByIdAsyncAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("This argument is null");
            var university = await repository.GetEntityByIdAsync(id);
            if (university is null)
                throw new ArgumentNullException("This argument is null");
            return UniversityMapper.UniversityDto(university);
        }

        public async Task<List<UniversityDto>> SearchUniversityAsync(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("This argument can't be null");
            var universities = await repository.GetAllEntitiesAsync();
            var retunUnies = universities.Where(x => x.Name.Contains(value, StringComparison.OrdinalIgnoreCase)).ToList();
            var returnList = retunUnies.Select(x => UniversityMapper.UniversityDto(x)).ToList();
            foreach (var uni in returnList)
            {
                Console.WriteLine($"{uni.Name},{uni.UniversityType}");
            }
            return returnList;
        }

        public async Task<UniversityDto> UpdateUniversityAsync(Guid id, UniversityUpdateDto universityUpdate)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty");

            await unitOfWork.BeginTransactionAsync();

            try
            {
                var university = await repository.GetEntityByIdAsync(id);

                if (university is null)
                    throw new ArgumentNullException("This argument doesn't exist");
                var duplicate = await repository.FirstOrDefaultAsync(x =>
                    x.Name == universityUpdate.Name &&
                    x.UniversityType == universityUpdate.UniversityType &&
                    x.Id != id);

                if (duplicate != null)
                    throw new InvalidOperationException("Same university already exists");
                if (university.Name == universityUpdate.Name &&
                    university.UniversityType == universityUpdate.UniversityType)
                    throw new InvalidOperationException("Updated entities can't be same");

                university.UpdateName(universityUpdate.Name);
                university.UpdateType(universityUpdate.UniversityType);

                repository.UpdateEntity(university);

                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitAsync();

                return UniversityMapper.UniversityDto(university);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}


