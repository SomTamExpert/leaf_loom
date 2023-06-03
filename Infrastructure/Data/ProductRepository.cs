using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
  public class ProductRepository : IProductRepository
  {
    StoreContext _context;
    public ProductRepository(StoreContext context)
    {
      _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      return await _context.Products
      .Include(p => p.ProductType)
      .Include(p => p.Pot)
      .Include(p => p.Images)
      .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
      return await _context.Products
      .Include(p => p.ProductType)
      .Include(p => p.Pot)
      .Include(p => p.Images)
      .ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
      return await _context.ProductTypes.ToListAsync();
    }

    public async Task<IReadOnlyList<Pot>> GetPotsAsync()
    {
      return await _context.Pots.ToListAsync();
    }

    public async Task<IReadOnlyList<Images>> GetImagesAsync()
    {
      return await _context.Images.ToListAsync();
    }

  }
}