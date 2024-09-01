using NotificationService.Application.Interfaces;
using NotificationService.Application.Queries;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Handlers;

public class NotificationTypeQueryHandler
{
    private readonly INotificationTypeService _notificationTypeService;

    public NotificationTypeQueryHandler(INotificationTypeService notificationTypeService)
    {
        _notificationTypeService = notificationTypeService;
    }

    public async Task<NotificationType?> Handle(GetNotificationTypeByIdQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var notificationType = await _notificationTypeService.GetNotificationTypeByIdAsync(query);
        return notificationType;
    }

    public async Task<IEnumerable<NotificationType?>> Handle()
    {
        var notificationTypes = await _notificationTypeService.GetAllNotificationTypesAsync();
        return notificationTypes;
    }
}
