using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces;

public interface INotificationRepository
{
    Task<Notification?> GetByIdAsync(Guid id);
    Task<IEnumerable<Notification>> GetAllAsync(Func<Notification, bool> predicate);
    Task AddAsync(Notification notification);
    void Update(Notification notification);
    void Remove(Notification notification);
}
