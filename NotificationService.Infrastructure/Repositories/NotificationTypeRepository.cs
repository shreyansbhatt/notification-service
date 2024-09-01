using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Data;

namespace NotificationService.Infrastructure.Repositories;

public class NotificationTypeRepository : INotificationTypeRepository
{
    private readonly NotificationContext _context;

    public NotificationTypeRepository(NotificationContext context)
    {
        _context = context;
    }

    public async Task<NotificationType?> GetByIdAsync(Guid id)
    {
        return await _context.NotificationTypes.FindAsync(id);
    }

    public async Task<IEnumerable<NotificationType?>> GetAllAsync()
    {
        return await _context.NotificationTypes.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(NotificationType notificationType)
    {
        await _context.NotificationTypes.AddAsync(notificationType);
    }

    public void Update(NotificationType notificationType)
    {
        _context.NotificationTypes.Update(notificationType);
    }

    public void Remove(NotificationType notificationType)
    {
        _context.NotificationTypes.Remove(notificationType);
    }
}
