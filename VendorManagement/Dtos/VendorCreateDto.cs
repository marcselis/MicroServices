using System.ComponentModel.DataAnnotations;

namespace VendorManagement.Dtos
{
    public class VendorCreateDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
