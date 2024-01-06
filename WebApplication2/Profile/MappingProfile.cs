using WebApplication2.DTO;

namespace WebApplication2.Profile;

public class MappingProfile:AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Operation, OperationUpdateDTO>();
        CreateMap<Type, TypeDTO>();
        CreateMap<ReportDTO, ReportDTO>();
    }
}