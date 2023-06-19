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
      CreateMap<Review, ReviewToReturnDTO>()
          .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
          .ForMember(t => t.Title, o => o.MapFrom(s => s.Title))
          .ForMember(t => t.Author, o => o.MapFrom(s => s.Author))
          .ForMember(t => t.Rating, o => o.MapFrom(s => s.Rating))
          .ForMember(t => t.Comment, o => o.MapFrom(s => s.Comment))
          .ForMember(t => t.ProductId, o => o.MapFrom(s => s.ProductId))
          .ForMember(t => t.ImageUrl, o => o.MapFrom(s => s.ImageUrl))
          .ForMember(t => t.Date, o => o.MapFrom(s => s.Date));
    }
  }
}