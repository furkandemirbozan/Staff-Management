using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IEducationLevelRepository : IRepository<EducationLevel>
    {
        Task<EducationLevel> UpdateAsync(EducationLevel education);
        Task<EducationLevel> DeleteAsync(EducationLevel education);
    }
}
