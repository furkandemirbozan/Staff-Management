using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        Task<Leave> UpdateAsync(Leave leave);
        Task<Leave> DeleteAsync(Leave leave);
    }
}
