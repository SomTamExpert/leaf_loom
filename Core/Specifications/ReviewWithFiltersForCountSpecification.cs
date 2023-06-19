using Core.Entities;

namespace Core.Specifications

{
  public class ReviewWithFiltersForCountSpecification : BaseSpecification<Review>
  {
    public ReviewWithFiltersForCountSpecification(ReviewSpecParam reviewParams)
      : base(x =>
      (string.IsNullOrEmpty(reviewParams.Search) || x.Title.ToLower().Contains(reviewParams.Search)) &&
      (!reviewParams.ProductId.HasValue || x.ProductId == reviewParams.ProductId))
    {

    }
  }
}