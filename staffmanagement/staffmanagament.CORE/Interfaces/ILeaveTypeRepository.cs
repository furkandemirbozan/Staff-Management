using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface ILeaveTypeRepository : IRepository<LeaveType>
    {
        Task<LeaveType> UpdateAsync(LeaveType leaveType);
        Task<LeaveType> DeleteAsync(LeaveType leaveType);
    }
}
