using AutoMapper;
using ProductsService.Dtos;
using ProductsService.Models;

namespace ProductManagement.Profiles
{
  public class ProductsProfile : Profile
  {
    public ProductsProfile()
    {
      CreateMap<Product, ProductReadDto>();
      CreateMap<Product, ProductDetailsReadDto>();
      CreateMap<ProductVersion, ProductVersionReadDto>();
      CreateMap<ProductCreateDto, Product>();
      CreateMap<ProductVersionCreateDto, ProductVersion>();
    }
  }
}
