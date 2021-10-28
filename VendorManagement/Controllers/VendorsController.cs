using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorManagement.Data;
using VendorManagement.Dtos;
using VendorManagement.Models;

namespace VendorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorRepo _repo;
        private readonly IMapper _mapper;

        public VendorsController(IVendorRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<VendorReadDto>), 200)]
        [HttpGet]
        public ActionResult<IEnumerable<VendorReadDto>> GetVendors()
        {
            Console.WriteLine("Getting vendors");
            return Ok(_mapper.Map<IEnumerable<VendorReadDto>>(_repo.GetAllVendors()));
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(VendorReadDto),200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}", Name ="GetVendorById")]
        public ActionResult<VendorReadDto> GetVendorById(int id)
        {
            Console.WriteLine($"Getting vendor {id}");
            var vendor = _repo.GetVendorById(id);
            if (vendor == null)
                return NotFound(id);
            return Ok(_mapper.Map<VendorReadDto>(vendor));  
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(VendorReadDto), 201)]
        [ProducesResponseType(400)]
        [HttpPut]
        public ActionResult<VendorReadDto> CreateVendor(VendorCreateDto vendor)
        {
            Console.WriteLine($"Creating vendor {vendor.Name}");
            var newVendor = _mapper.Map<Vendor>(vendor);
            _repo.CreateVendor(newVendor);
            _repo.SaveChanges();
            var createdVendor = _mapper.Map<VendorReadDto>(newVendor);
            return CreatedAtRoute(nameof(GetVendorById), new { createdVendor.Id }, createdVendor);
        }
    }
}
