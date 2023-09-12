namespace Core.Entities

{
  public class BasketItem
  {
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Pot { get; set; }
    public Images Images { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }
  }

}