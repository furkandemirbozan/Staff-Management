using Microsoft.EntityFrameworkCore;
using staffmanagament.BUSINESS.Interfaces;
using staffmanagament.CORE.DTOs;
using staffmanagament.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.BUSINESS.Concrete
{
    public class NationalHolidayService: INationalHolidayService
    {
        private readonly AppDbContext _context;

        public NationalHolidayService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UpcomingNationalHolidayDto>> GetUpcomingNationalHolidaysAsync()
        {
            var today = DateTime.Today;
            var holidays = await _context.NationalHolidays
                .Where(h => h.StartDate >= today)
                .OrderBy(h => h.StartDate)
                .Take(5)
                .Select(h => new UpcomingNationalHolidayDto
                {
                    NationalHolidayName = h.Name,
                    NationalHolidayStartDate = h.StartDate,
                    NationalHolidayEndDate = h.EndDate
                })
                .ToListAsync();

            return holidays;
        }
    }
}
