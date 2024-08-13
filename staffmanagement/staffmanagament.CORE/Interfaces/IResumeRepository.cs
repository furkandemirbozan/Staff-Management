using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IResumeRepository : IRepository<Resume>
    {
        Task<Resume> UpdateAsync(Resume resume);
        Task<Resume> DeleteAsync(Resume resume);
    }
}
