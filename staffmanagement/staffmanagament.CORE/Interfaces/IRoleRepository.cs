using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> UpdateAsync(Role role);
        Task<Role> DeleteAsync(Role role);
    }
}
