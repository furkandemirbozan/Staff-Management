using Microsoft.EntityFrameworkCore;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.DAL;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Event> DeleteAsync(Event @event)
    {
        _context.Entry(@event).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return @event;
    }

    public async Task<Event> UpdateAsync(Event @event)
    {
        _context.Events.Update(@event);
        await _context.SaveChangesAsync();
        return @event;
    }

}
