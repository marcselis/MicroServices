using VendorManagement.Models;

namespace VendorManagement.Data
{
    public interface IVendorRepo
    {
        bool SaveChanges();
        IEnumerable<Vendor> GetAllVendors();
        Vendor? GetVendorById(int id);
        void CreateVendor(Vendor vendor);
    }
}
