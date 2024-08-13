using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> UpdateAsync(Event eventt);
        Task<Event> DeleteAsync(Event eventt);
    }
}
