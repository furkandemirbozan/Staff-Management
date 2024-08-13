using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.DAL;

public class RequestStatusRepository : Repository<RequestStatus>, IRequestStatusReposity
{
    public RequestStatusRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<RequestStatus> DeleteAsync(RequestStatus requestStatus)
    {
        _context.Entry(requestStatus).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return requestStatus;
    }

    public async Task<RequestStatus> UpdateAsync(RequestStatus requestStatus)
    {
        _context.RequestStatuses.Update(requestStatus);
        await _context.SaveChangesAsync();
        return requestStatus;
    }

}
