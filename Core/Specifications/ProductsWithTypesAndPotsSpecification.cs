using Core.Entities;

namespace Core.Specifications
{
  public class ProductsWithTypesAndPotsAndImagesSpecification : BaseSpecification<Product>
  {

    public ProductsWithTypesAndPotsAndImagesSpecification()
    {
      AddInclude(x => x.ProductType);
      AddInclude(x => x.Pot);
      AddInclude(x => x.Images);
    }

    public ProductsWithTypesAndPotsAndImagesSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.ProductType);
      AddInclude(x => x.Pot);
      AddInclude(x => x.Images);
    }
  }
}