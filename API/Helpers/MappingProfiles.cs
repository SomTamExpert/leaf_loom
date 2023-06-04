using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers

{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<Product, ProductToReturnDTO>()
        .ForMember(t => t.ProductType, o => o.MapFrom(s => s.ProductType.Name))
        .ForMember(t => t.Pot, o => o.MapFrom(s => s.Pot.Color))
        .ForMember(t => t.Images, o => o.MapFrom(s => s.Images.Grey))
        .ForMember(t => t.Images, o => o.MapFrom<ProductUrlResolver>());
    }
  }
}