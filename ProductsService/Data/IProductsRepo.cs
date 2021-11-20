using ProductsService.Models;
using System;

namespace ProductsService.Data
{
  public interface IProductsRepo
  {
    bool SaveChanges();
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int id);
    void CreateProduct(Product vendor);
  }
}