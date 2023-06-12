using API.Dtos;
using API.Helpers.API.Helpers;
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

      CreateMap<Images, ImagesToReturnDTO>()
          .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
          .ForMember(t => t.White, o => o.MapFrom<ImagesURLResolver, string>(src => src.White))
          .ForMember(t => t.Brown, o => o.MapFrom<ImagesURLResolver, string>(src => src.Brown))
          .ForMember(t => t.Purple, o => o.MapFrom<ImagesURLResolver, string>(src => src.Purple))
          .ForMember(t => t.Grey, o => o.MapFrom<ImagesURLResolver, string>(src => src.Grey));


    }
  }
}