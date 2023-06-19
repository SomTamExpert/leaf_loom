using Core.Entities;

namespace Core.Specifications
{
  public class ReviewWithProductAndDateSpecification : BaseSpecification<Review>
  {
    public ReviewWithProductAndDateSpecification(ReviewSpecParam reviewParams)
      : base(x =>
      (string.IsNullOrEmpty(reviewParams.Search) || x.Title.ToLower().Contains(reviewParams.Search)) &&
      (!reviewParams.ProductId.HasValue || x.ProductId == reviewParams.ProductId))
    {
      AddInclude(x => x.Product); // Include the Product navigation property
      AddOrderBy(x => x.Date);
      ApplyPaging(reviewParams.PageSize * (reviewParams.PageIndex - 1), reviewParams.PageSize);

      if (!string.IsNullOrEmpty(reviewParams.Sort))
      {
        switch (reviewParams.Sort)
        {
          case "dateAsc":
            AddOrderBy(p => p.Date);
            break;
          case "dateDesc":
            AddOrderByDescending(p => p.Date);
            break;
          default:
            AddOrderBy(n => n.Title);
            break;
        }
      }
    }
  }
}
