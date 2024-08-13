using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.DAL;

public class GenderRepository : Repository<Gender>, IGenderRepository
{
    public GenderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Gender> DeleteAsync(Gender gender)
    {
        _context.Entry(gender).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return gender;
    }

    public async Task<Gender> UpdateAsync(Gender gender)
    {
        _context.Genders.Update(gender);
        await _context.SaveChangesAsync();
        return gender;
    }
}
