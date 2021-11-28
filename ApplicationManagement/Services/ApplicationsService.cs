using ApplicationsService.Data;
using AutoMapper;
using Grpc.Core;

namespace ApplicationManagement.Services
{
  public class ApplicationsService : Applications.ApplicationsBase
  {
    private readonly IApplicationsRepo _repo;
    private readonly IMapper _mapper;

    public ApplicationsService(IApplicationsRepo repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }
    public override async Task<GrpcApplicationModel> GetApplication(ApplicationRequest request, ServerCallContext context)
    {
      var app = await _repo.GetApplicationByIdAsync(request.ApplicationId).ConfigureAwait(false);
      return _mapper.Map<GrpcApplicationModel>(app);
    }
  }
}
