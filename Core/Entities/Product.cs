namespace Core.Entities
{
  public class Product : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public string Care { get; set; }
    public string Price { get; set; }

    public ProductType ProductType { get; set; }

    public int ProductTypeId { get; set; }

    public Pot Pot { get; set; }

    public int PotId { get; set; }

    public Images Images { get; set; }

    public int ImagesId { get; set; }
  }
}