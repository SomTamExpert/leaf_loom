using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
  public class StoreContextSeed
  {

    public static async Task SeedAsync(StoreContext context)
    {
      if (!context.ProductTypes.Any())
      {
        var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
        context.ProductTypes.AddRange(types);
      }

      if (!context.Pots.Any())
      {
        var potsData = File.ReadAllText("../Infrastructure/Data/SeedData/pots.json");
        System.Console.Write("pots data ", potsData);
        var pots = JsonSerializer.Deserialize<List<Pot>>(potsData);
        context.Pots.AddRange(pots);
      }

      if (!context.Products.Any())
      {
        var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
        var products = JsonSerializer.Deserialize<List<Product>>(productsData);
        context.Products.AddRange(products);
      }

      if (!context.Images.Any())
      {
        var imagesData = File.ReadAllText("../Infrastructure/Data/SeedData/images.json");
        var images = JsonSerializer.Deserialize<List<Images>>(imagesData);
        context.Images.AddRange(images);
      }

      if (context.ChangeTracker.HasChanges())
      {
        await context.SaveChangesAsync();
      }
    }

  }
}

