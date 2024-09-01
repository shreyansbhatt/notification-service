using NotificationService.Application.Commands;
using NotificationService.Application.Queries;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces;

public interface INotificationService
{
    Task<Result<Notification>> SendNotificationAsync(SendNotificationCommand command);
    Task<Notification?> GetNotificationByIdAsync(GetNotificationByIdQuery query);
    Task<IEnumerable<Notification>> GetAllNotificationsAsync(GetAllNotificationsQuery query);
    Task<Result> DeleteNotificationAsync(DeleteNotificationCommand command);
}
