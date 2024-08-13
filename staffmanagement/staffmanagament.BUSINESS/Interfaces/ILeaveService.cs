using staffmanagament.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.BUSINESS.Interfaces
{
    public interface ILeaveService
    {
        Task<LeaveCardDto> GetLeaveCardAsync(int employeeId);
    }
}
