using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.DAL.Repositories
{
    public class EducationLevelRepository : Repository<EducationLevel>, IEducationLevelRepository
    {
        public EducationLevelRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<EducationLevel> DeleteAsync(EducationLevel educationLevel)
        {
            _context.Entry(educationLevel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return educationLevel;
        }

        public async Task<EducationLevel> UpdateAsync(EducationLevel educationLevel)
        {
            _context.EducationLevels.Update(educationLevel);
            await _context.SaveChangesAsync();
            return educationLevel;
        }
    }
}
