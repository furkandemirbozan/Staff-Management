using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IGenderRepository : IRepository<Gender>
    {
        Task<Gender> UpdateAsync(Gender gender);
        Task<Gender> DeleteAsync(Gender gender);
    }
}
