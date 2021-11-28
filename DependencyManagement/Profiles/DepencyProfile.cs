using AutoMapper;
using DependencyManagement.Dtos;
using DependencyManagement.Models;

namespace ProductManagement.Profiles
{
  public class PackagesProfile : Profile
  {
    public PackagesProfile()
    {
      CreateMap<Package, PackageReadDto>();
    }
  }
}
