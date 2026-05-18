namespace UniversityApp.BLL.Profile
{
    public static class UniversityMapper
    {
        public static University CreateUniversityDto(UniversityCreateDto universityCreate)
        {
            return new University(
                    universityCreate.Name,
                    universityCreate.UniversityType
                );
        }

        public static UniversityDto UniversityDto(University university)
        {
            return new UniversityDto(
                university.Id,
                university.Name,
                university.UniversityType

                );
        }

    }
}




