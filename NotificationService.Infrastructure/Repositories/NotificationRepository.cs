using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Data;

namespace NotificationService.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly NotificationContext _context;

    public NotificationRepository(NotificationContext context)
    {
        _context = context;
    }

    public async Task<Notification?> GetByIdAsync(Guid id)
    {
        return await _context.Notifications.FindAsync(id);
    }

    public async Task<IEnumerable<Notification>> GetAllAsync(Func<Notification, bool> predicate)
    {
        return await Task.FromResult(_context.Notifications.AsNoTracking().Where(predicate));
    }

    public async Task AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
    }

    public void Update(Notification notification)
    {
        _context.Notifications.Update(notification);
    }

    public void Remove(Notification notification)
    {
        _context.Notifications.Remove(notification);
    }
}
