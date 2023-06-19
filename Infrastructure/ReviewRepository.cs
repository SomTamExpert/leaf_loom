using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
  public class ReviewRepository : IReviewRepository
  {
    StoreContext _context;
    public ReviewRepository(StoreContext context)
    {
      _context = context;
    }

    public Task<Review> GetReviewByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public async  Task<IReadOnlyList<Review>> GetReviewsByProductIdAsync(int productId)
    {
      return await _context.Reviews
      .Include(r => r.Product)
      .ToListAsync();
    }

    public Task<Review> SaveReviewAsync(Review review)
    {
      throw new NotImplementedException();
    }
  }

}