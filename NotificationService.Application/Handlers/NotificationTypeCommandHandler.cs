using NotificationService.Application.Commands;
using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Handlers;

public class NotificationTypeCommandHandler
{
    private readonly INotificationTypeService _notificationTypeService;

    public NotificationTypeCommandHandler(INotificationTypeService notificationTypeService)
    {
        _notificationTypeService = notificationTypeService;
    }

    public async Task<Result<NotificationType>> Handle(CreateNotificationTypeCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        var result = await _notificationTypeService.CreateNotificationTypeAsync(command);
        return result;
    }

    public async Task<Result<NotificationType>> Handle(UpdateNotificationTypeCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        var result = await _notificationTypeService.UpdateNotificationTypeAsync(command);
        return result;
    }

    public async Task<Result> Handle(DeleteNotificationTypeCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        var result = await _notificationTypeService.DeleteNotificationTypeAsync(command);
        return result;
    }
}
