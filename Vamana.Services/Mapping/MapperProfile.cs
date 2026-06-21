using AutoMapper;
using Vamana.AMS.Core.Entities.Students;
using Vamana.AMS.Core.Models.Students;

namespace Vamana.AMS.Services.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentModel>()
            .ReverseMap();
    }
}
