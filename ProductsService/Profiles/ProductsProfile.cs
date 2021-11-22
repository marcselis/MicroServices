using AutoMapper;
using ProductsService.Dtos;
using ProductsService.Models;

namespace ProductManagement.Profiles
{
  public class ProductsProfile : Profile
  {
    public ProductsProfile()
    {
      CreateMap<Product, ProductReadDto>()
        .ForMember(p => p.LifeCycle, opt => opt.MapFrom(p => p.Lifecycle.Current));
      CreateMap<Product, ProductDetailsReadDto>();
      CreateMap<ProductVersion, ProductVersionReadDto>()
        .ForMember(pv => pv.LifeCycle, opt => opt.MapFrom(pv => pv.Lifecycle.Current));
      CreateMap<ProductCreateDto, Product>();
      CreateMap<ProductVersionCreateDto, ProductVersion>();
      CreateMap<LifeCycleInfo, LifeCycleInfoDto>();
    }
  }
}
