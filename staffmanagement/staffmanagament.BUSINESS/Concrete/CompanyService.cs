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
    public class CompanyService: ICompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UpcomingBirthdaysDto>> GetUpcomingBirthdaysAsync(int companyId)
        {
            var today = DateTime.Today;
            var employees = await _context.Employees
            .Include(e => e.Department)
                .Where(e => e.Id == companyId)
                .OrderBy(e => EF.Functions.DateDiffDay(today, e.BirthDate))
                .Select(e => new UpcomingBirthdaysDto
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    BirthDate = e.BirthDate,
                    EmployeeImageUrl = e.ImageUrl
                })
                .ToListAsync();

            return employees;
        }
    }
}
