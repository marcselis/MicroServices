using VendorManagement.Models;

namespace VendorManagement.Data
{
    public class VendorRepo : IVendorRepo
    {
        private readonly AppDbContext _context;

        public VendorRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor??throw new ArgumentNullException(nameof(vendor)));
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return _context.Vendors;
        }

        public Vendor? GetVendorById(int id)
        {
            return _context.Vendors.FirstOrDefault(v => v.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
