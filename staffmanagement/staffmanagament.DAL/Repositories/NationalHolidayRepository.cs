using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.DAL.Repositories
{
    public class NationalHolidayRepository : Repository<NationalHoliday>, INationalHolidayRepository
    {
        public NationalHolidayRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<NationalHoliday> DeleteAsync(NationalHoliday nationalHoliday)
        {
            _context.Entry(nationalHoliday).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return nationalHoliday;
        }

        public async Task<NationalHoliday> UpdateAsync(NationalHoliday nationalHoliday)
        {
            _context.NationalHolidays.Update(nationalHoliday);
            await _context.SaveChangesAsync();
            return nationalHoliday;
        }
    }

}
