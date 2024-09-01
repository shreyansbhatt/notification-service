using NotificationService.Application.Commands;
using NotificationService.Application.Queries;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces;

public interface INotificationTypeService
{
    Task<Result<NotificationType>> CreateNotificationTypeAsync(CreateNotificationTypeCommand command);
    Task<Result<NotificationType>> UpdateNotificationTypeAsync(UpdateNotificationTypeCommand command);
    Task<Result> DeleteNotificationTypeAsync(DeleteNotificationTypeCommand command);
    Task<NotificationType?> GetNotificationTypeByIdAsync(GetNotificationTypeByIdQuery query);
    Task<IEnumerable<NotificationType?>> GetAllNotificationTypesAsync();
}
