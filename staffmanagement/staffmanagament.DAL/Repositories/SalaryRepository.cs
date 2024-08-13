using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.DAL;

public class SalaryRepository : Repository<Salary>, ISalaryRepository
{
    public SalaryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Salary> DeleteAsync(Salary salary)
    {
        _context.Entry(salary).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return salary;
    }

    public async Task<Salary> UpdateAsync(Salary salary)
    {
        _context.Salaries.Update(salary);
        await _context.SaveChangesAsync();
        return salary;
    }

}
