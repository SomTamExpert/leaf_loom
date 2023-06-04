using Core.Entities;

namespace API.Dtos
{
  public class ProductToReturnDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Care { get; set; }
    public string Price { get; set; }
    public string ProductType { get; set; }
    public string Pot { get; set; }
    public string Images { get; set; }

  }
}