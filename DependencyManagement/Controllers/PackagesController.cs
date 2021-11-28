using AutoMapper;
using DependencyManagement.Data;
using DependencyManagement.Dtos;
using DependencyManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace PackagesService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PackagesController : ControllerBase
  {
    private readonly IPackagesRepo _repo;
    private readonly IMapper _mapper;

    public PackagesController(IPackagesRepo repo, IMapper mapper)
    {
      _repo = repo;
      _mapper= mapper;
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<PackageReadDto>), 200)]
    [HttpGet]
    public ActionResult<IEnumerable<PackageReadDto>> GetPackages()
    {
      Console.WriteLine("Getting Packages");
      return Ok(_mapper.Map<IEnumerable<PackageReadDto>>(_repo.GetAllPackages()));
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(PackageReadDto), 200)]
    [ProducesResponseType(404)]
    [HttpGet("{id}", Name = "GetPackageById")]
    public ActionResult<PackageReadDto> GetPackageById(int id)
    {
      Console.WriteLine($"Getting package {id}");
      var Package = _repo.GetPackageById(id);
      if (Package == null)
      {
        return NotFound(id);
      }
      return Ok(_mapper.Map<PackageReadDto>(Package));
    }


    [Produces("application/json")]
    [ProducesResponseType(typeof(PackageReadDto), 201)]
    [ProducesResponseType(400)]
    [HttpPut]
    public ActionResult<PackageReadDto> CreateVendor(PackageCreateDto Package)
    {
      Console.WriteLine($"Creating Package {Package.Name}");
      var newPackage = _mapper.Map<Package>(Package);
      _repo.CreatePackage(newPackage);
      _repo.SaveChanges();
      var createdPackage = _mapper.Map<PackageReadDto>(newPackage);
      return CreatedAtRoute(nameof(GetPackageById), new { createdPackage.Id }, createdPackage);
    }

  }
}
