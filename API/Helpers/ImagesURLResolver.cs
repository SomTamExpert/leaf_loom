using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
  using AutoMapper;
  using Core.Entities;

  namespace API.Helpers
  {
    public class ImagesURLResolver : IMemberValueResolver<Images, ImagesToReturnDTO, string, string>
    {
      private readonly IConfiguration _config;

      public ImagesURLResolver(IConfiguration config)
      {
        _config = config;
      }

      public string Resolve(Images source, ImagesToReturnDTO destination, string sourceMember, string destMember, ResolutionContext context)
      {
        var imageUrl = _config["ApiUrl"] + sourceMember;
        System.Console.WriteLine(destMember + ": " + imageUrl);
        return imageUrl;
      }
    }
  }



}
