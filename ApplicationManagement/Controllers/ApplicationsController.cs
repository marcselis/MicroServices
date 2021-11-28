using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApplicationsService.Data;
using ApplicationsService.Dtos;
using ApplicationsService.Models;

namespace ApplicationsService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ApplicationsController : ControllerBase
  {
    private readonly IApplicationsRepo _repo;
    private readonly IMapper _mapper;

    public ApplicationsController(IApplicationsRepo repo, IMapper mapper)
    {
      _repo = repo;
      _mapper= mapper;
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ApplicationReadDto>), 200)]
    [HttpGet]
    public ActionResult<IEnumerable<ApplicationReadDto>> GetApplications()
    {
      Console.WriteLine("Getting Applications");
      return Ok(_mapper.Map<IEnumerable<ApplicationReadDto>>(_repo.GetAllApplications()));
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ApplicationDetailsReadDto), 200)]
    [ProducesResponseType(404)]
    [HttpGet("{id}", Name = "GetApplicationById")]
    public async Task<ActionResult<ApplicationDetailsReadDto>> GetApplicationById(int id)
    {
      Console.WriteLine($"Getting vendor {id}");
      var Application = await _repo.GetApplicationByIdAsync(id).ConfigureAwait(false);
      if (Application == null)
      {
        return NotFound(id);
      }
      return Ok(_mapper.Map<ApplicationDetailsReadDto>(Application));
    }

    [HttpHead("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApplicationDetailsReadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> ApplicationExists(long id)
    {
      Console.WriteLine($"Checking whether application {id} exists.");
      if (await _repo.CheckApplicationExistsAsync(id).ConfigureAwait(false))
      {
        return Ok();
      }
      return NotFound(id);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ApplicationDetailsReadDto), 201)]
    [ProducesResponseType(400)]
    [HttpPut]
    public async Task<ActionResult<ApplicationDetailsReadDto>> CreateApplication(ApplicationCreateDto Application)
    {
      Console.WriteLine($"Creating Application {Application.Name}");
      var newApplication = _mapper.Map<Application>(Application);
      await _repo.CreateApplicationAsync(newApplication).ConfigureAwait(false);
      await _repo.SaveChangesAsync().ConfigureAwait(false);
      var createdApplication = _mapper.Map<ApplicationDetailsReadDto>(newApplication);
      return CreatedAtRoute(nameof(GetApplicationById), new { createdApplication.Id }, createdApplication);
    }

  }
}
