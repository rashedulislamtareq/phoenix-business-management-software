using AutoMapper;
using Phoenix.BusinessManagement.ClientModel.Models.HealthCheck;
using Phoenix.BusinessManagement.Entity.Domain.HealthCheck;

namespace Phoenix.BusinessManagement.ClientModel.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Health Check
            CreateMap<Application, HealthCheckCreateVM>().ReverseMap();
            CreateMap<Application, HealthCheckUpdateVM>().ReverseMap();
            CreateMap<Application, HealthCheckListVM>().ReverseMap();
            CreateMap<Application, HealthCheckDetailVM>().ReverseMap();
        }
    }
}
