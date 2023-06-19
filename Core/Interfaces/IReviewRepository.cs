using Core.Entities;

namespace Core.Interfaces
{
  public interface IReviewRepository
  {
    Task<Review> GetReviewByIdAsync(int id);

    Task<IReadOnlyList<Review>> GetReviewsByProductIdAsync(int productId);

    Task<Review> SaveReviewAsync(Review review);
  }
}