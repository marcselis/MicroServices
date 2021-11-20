using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Data;
using ProductsService.Dtos;
using ProductsService.Models;

namespace ProductsService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductsRepo _repo;
    private readonly IMapper _mapper;

    public ProductsController(IProductsRepo repo, IMapper mapper)
    {
      _repo = repo;
      _mapper= mapper;
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ProductReadDto>), 200)]
    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
    {
      Console.WriteLine("Getting products");
      return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(_repo.GetAllProducts()));
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ProductDetailsReadDto), 200)]
    [ProducesResponseType(404)]
    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<ProductDetailsReadDto> GetProductById(int id)
    {
      Console.WriteLine($"Getting vendor {id}");
      var product = _repo.GetProductById(id);
      if (product == null)
      {
        return NotFound(id);
      }
      return Ok(_mapper.Map<ProductDetailsReadDto>(product));
    }


    [Produces("application/json")]
    [ProducesResponseType(typeof(ProductDetailsReadDto), 201)]
    [ProducesResponseType(400)]
    [HttpPut]
    public ActionResult<ProductDetailsReadDto> CreateVendor(ProductCreateDto product)
    {
      Console.WriteLine($"Creating product {product.Name}");
      var newProduct = _mapper.Map<Product>(product);
      _repo.CreateProduct(newProduct);
      _repo.SaveChanges();
      var createdProduct = _mapper.Map<ProductDetailsReadDto>(newProduct);
      return CreatedAtRoute(nameof(GetProductById), new { createdProduct.Id }, createdProduct);
    }

  }
}
