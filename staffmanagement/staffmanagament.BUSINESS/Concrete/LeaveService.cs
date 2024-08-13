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
    public class LeaveService:ILeaveService
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeServices _employeeService;

        public LeaveService(AppDbContext context, IEmployeeServices employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public async Task<LeaveCardDto> GetLeaveCardAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee == null)
            {
                return null;
            }

            var leaves = await _context.Leaves
                .Where(l => l.EmployeeId == employeeId)
                .Include(l => l.LeaveType)
                .ToListAsync();

            var leaveDetails = leaves.Select(l => new LeaveDetailDto
            {
                LeaveType = l.LeaveType.Name,
                StartDate = l.StartDate,
                EndDate = l.EndDate
            }).ToList();

            var leaveCard = new LeaveCardDto
            {
                RemainingLeaveDays = employee.RemainingLeaveDays,
                Leaves = leaveDetails
            };

            return leaveCard;
        }
    }
}
