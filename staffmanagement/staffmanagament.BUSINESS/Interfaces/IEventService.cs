using Microsoft.EntityFrameworkCore.Diagnostics;
using staffmanagament.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.BUSINESS.Interfaces
{
    public interface IEventService
    {
        Task<List<UpcomingEventsDto>> GetUpcomingEventsAsync(int companyId);
    }
}
