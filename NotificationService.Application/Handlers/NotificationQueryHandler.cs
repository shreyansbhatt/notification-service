using NotificationService.Application.Interfaces;
using NotificationService.Application.Queries;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Handlers;

public class NotificationQueryHandler
{
    private readonly INotificationService _notificationService = null!;

    public NotificationQueryHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<Notification?> Handle(GetNotificationByIdQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var notification = await _notificationService.GetNotificationByIdAsync(query);
        return notification;
    }

    public async Task<IEnumerable<Notification?>> Handle(GetAllNotificationsQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var notifications = await _notificationService.GetAllNotificationsAsync(query);
        return notifications;
    }
}
