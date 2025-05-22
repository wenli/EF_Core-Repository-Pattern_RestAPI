using AutoMapper;
using BrandApplication.Business.DTOs;
using BrandApplication.DataAccess.Models; // Existing, for Brand, ProductModel
using BrandApplication.DataAccess.Entities; // Added for BtStrategy

namespace BrandApplication.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<ProductModel, ModelDto>().ReverseMap();
            CreateMap<BtStrategy, BtStrategyDto>().ReverseMap(); // Added this line
        }
    }
}
