using Microsoft.AspNetCore.Mvc;

namespace DeployService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DeploysController : ControllerBase
  {

    private readonly ILogger<DeploysController> _logger;

    public DeploysController(ILogger<DeploysController> logger)
    {
      _logger = logger;
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(DeployReadDto), 201)]
    [ProducesResponseType(400)]
    [HttpPut]
    public Task<ActionResult<DeployReadDto>> CreateDeploy([FromBody] DeployCreateDto deploy)
    {
      using (_logger.BeginScope(deploy))
      {
        return Task.FromResult<ActionResult<DeployReadDto>>(Ok(new DeployReadDto()));

      }
    }
  }
}