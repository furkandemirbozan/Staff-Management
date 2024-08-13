using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.DAL;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Department> DeleteAsync(Department department)
    {
        _context.Entry(department).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department> UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return department;
    }
}
