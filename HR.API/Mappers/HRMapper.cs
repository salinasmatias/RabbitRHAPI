using AutoMapper;
using HR.Domain.Dtos;
using HR.Domain.Models;

namespace HR.API.Mappers
{
    public class HRMapper : Profile
    {
        public HRMapper()
        {
            CreateMap<Country, CountryDto>().ForMember(x => x.Region, option => option.MapFrom(source => source.Region.RegionName));
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
        }
    }
}
