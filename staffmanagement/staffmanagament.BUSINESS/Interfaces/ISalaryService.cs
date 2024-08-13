using staffmanagament.CORE.DTOs;
using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.BUSINESS.Interfaces
{
    public interface ISalaryService
    {
        public Task<IEnumerable<SalaryDto>> GetSalaries();
        public Task<SalaryDto> GetSalary(int id);
        public Task<SalaryDto> AddSalary(SalaryDto salary);
        public Task<SalaryDto> UpdateSalary(int id, SalaryDto salary);
        public Task<SalaryDto> DeleteSalary(int id);

    }
}
