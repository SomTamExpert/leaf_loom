using Core.Entities;

namespace Core.Specifications
{
  public class ProductsWithTypesAndPotsAndImagesSpecification : BaseSpecification<Product>
  {

    public ProductsWithTypesAndPotsAndImagesSpecification(ProductSpecParams productParams)
      : base(x =>
         (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
         (!productParams.ProductTypeId.HasValue || x.ProductTypeId == productParams.ProductTypeId)
       )
    {
      AddInclude(x => x.ProductType);
      AddInclude(x => x.Pot);
      AddInclude(x => x.Images);
      AddOrderBy(x => x.Name);
      ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

      if (!string.IsNullOrEmpty(productParams.Sort))
      {
        switch (productParams.Sort)
        {
          case "priceAsc":
            AddOrderBy(p => p.Price);
            break;
          case "priceDesc":
            AddOrderByDescending(p => p.Price);
            break;
          default:
            AddOrderBy(n => n.Name);
            break;
        }
      }
    }
    public ProductsWithTypesAndPotsAndImagesSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.ProductType);
      AddInclude(x => x.Pot);
      AddInclude(x => x.Images);
    }
  }
}