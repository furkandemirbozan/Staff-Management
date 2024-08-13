using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.DAL;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Address> DeleteAsync(Address address)
    {
        _context.Entry(address).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address> UpdateAsync(Address address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
        return address;
    }
}
