using AutoMapper;
using VendorManagement.Dtos;
using VendorManagement.Models;

namespace VendorManagement.Profiles
{
    public class VendorsProfile : Profile
    {
        public VendorsProfile()
        {
            CreateMap<Vendor, VendorReadDto>();
            CreateMap<VendorCreateDto, Vendor>();
        }
    }
}
