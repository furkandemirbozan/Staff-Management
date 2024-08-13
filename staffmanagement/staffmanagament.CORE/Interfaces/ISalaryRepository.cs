using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        Task<Salary> UpdateAsync(Salary salary);
        Task<Salary> DeleteAsync(Salary salary);
    }
}
