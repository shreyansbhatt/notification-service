using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces;

public interface INotificationTypeRepository
{
    Task<NotificationType?> GetByIdAsync(Guid id);
    Task<IEnumerable<NotificationType?>> GetAllAsync();
    Task AddAsync(NotificationType notificationType);
    void Update(NotificationType notificationType);
    void Remove(NotificationType notificationType);
}
