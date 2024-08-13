using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> UpdateAsync(Department department);
        Task<Department> DeleteAsync(Department department);
    }
}
