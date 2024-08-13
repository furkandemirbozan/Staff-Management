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
    public class CalendarService:ICalendarService
    {
        private readonly AppDbContext _context;

        public CalendarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CalendarEventDto>> GetCompanyCalendarEventsAsync(int companyId)
        {
            var companyEmployees = await _context.Employees
                            .Include(e => e.Department)
                            .Where(e => e.Department.CompanyId == companyId)
                            .Select(e => new CalendarEventDto
                            {
                                Title = $"{e.FirstName} {e.LastName}'s Birthday",
                                Start = e.BirthDate,
                                End = e.BirthDate,
                                Type = "Birthday",
                                Description = $"{e.FirstName} {e.LastName}'s Birthday"
                            }).ToListAsync();

            var companyEvents = await _context.Events
                .Where(e => e.CompanyId == companyId)
                .Select(e => new CalendarEventDto
                {
                    Title = e.Name,
                    Start = e.StartDate,
                    End = e.EndDate,
                    Type = "Event",
                    Description = e.Description
                }).ToListAsync();

            var nationalHolidays = await _context.NationalHolidays
                .Select(h => new CalendarEventDto
                {
                    Title = h.Name,
                    Start = h.StartDate,
                    End = h.EndDate,
                    Type = "NationalHoliday",
                    Description = h.Name
                }).ToListAsync();

            return companyEmployees.Concat(companyEvents).Concat(nationalHolidays).ToList();
        }
    }
}
