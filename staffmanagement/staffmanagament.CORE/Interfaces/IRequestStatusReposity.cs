using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IRequestStatusReposity : IRepository<RequestStatus>
    {
        Task<RequestStatus> UpdateAsync(RequestStatus requestStatus);
        Task<RequestStatus> DeleteAsync(RequestStatus requestStatus);
    }
}
