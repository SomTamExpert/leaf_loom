namespace API.Dtos
{
  public class ReviewToReturnDTO
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string Rating { get; set; }
    public string Author { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
    public string Date { get; set; }
  }
}