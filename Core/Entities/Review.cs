namespace Core.Entities
{
  public class Review : BaseEntity
  {
    public string Title { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public string Author { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string ImageUrl { get; set; }
    public string ImageUrl2 { get; set; }
    public string Date { get; set; }
  }
}