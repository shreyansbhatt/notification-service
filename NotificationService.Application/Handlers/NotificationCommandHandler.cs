using NotificationService.Application.Commands;
using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Handlers;

public class NotificationCommandHandler
{
    private readonly INotificationService _notificationService;

    public NotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<Result<Notification>> Handle(SendNotificationCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        var result = await _notificationService.SendNotificationAsync(command);
        return result;
    }

    public async Task<Result> Handle(DeleteNotificationCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        var result = await _notificationService.DeleteNotificationAsync(command);
        return result;
    }
}
