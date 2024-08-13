using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using staffmanagament.CORE.Models;

namespace staffmanagament.CORE.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<Job> UpdateAsync(Job job);
        Task<Job> DeleteAsync(Job job);
    }
}
