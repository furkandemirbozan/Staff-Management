using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.DAL;

public class ResumeRepository : Repository<Resume>, IResumeRepository
{
    public ResumeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Resume> DeleteAsync(Resume resume)
    {
        _context.Entry(resume).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return resume;
    }

    public async Task<Resume> UpdateAsync(Resume resume)
    {
        _context.Resumes.Update(resume);
        await _context.SaveChangesAsync();
        return resume;
    }
}
