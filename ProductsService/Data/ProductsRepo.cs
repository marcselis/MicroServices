using Microsoft.EntityFrameworkCore;
using ProductsService.Models;

namespace ProductsService.Data
{
  public class ProductsRepo : IProductsRepo
  {
    private readonly AppDbContext _context;
    public ProductsRepo(AppDbContext context)
    {
      _context = context;
    }

    public void CreateProduct(Product product)
    {
      _context.Products.Add(product ?? throw new ArgumentNullException(nameof(product)));
    }

    public IEnumerable<Product> GetAllProducts()
    {
      return _context.Products;
    }

    public Product? GetProductById(int id)
    {
      return _context.Products.Include(p => p.Versions).FirstOrDefault(v => v.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }
  }
}