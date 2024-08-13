using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task UpdateAsync(Company company);
        Task DeleteAsync(Company company);
    }
}
