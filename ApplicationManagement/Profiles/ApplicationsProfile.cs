using AutoMapper;
using ApplicationsService.Dtos;
using ApplicationsService.Models;

namespace ApplicationManagement.Profiles
{
  public class ApplicationsProfile : Profile
  {
    public ApplicationsProfile()
    {
      CreateMap<Application, ApplicationReadDto>();
      CreateMap<Application, ApplicationDetailsReadDto>();
      CreateMap<Component, ComponentReadDto>();
      CreateMap<ApplicationCreateDto, Application>();
      CreateMap<ComponentCreateDto, Component>();
      CreateMap<Application, GrpcApplicationModel>();
    }
  }
}
