using Channel = NotificationService.Domain.Enums.Channel;

namespace NotificationService.Application.Commands;

public class CreateNotificationCommand
{
    public Guid UserId { get; set; }
    public Guid NotificationTypeId { get; set; }
    public Channel Channel { get; set; }
    public string Content { get; set; }

    public CreateNotificationCommand(Guid userId, Guid notificationTypeId, Channel channel, string content)
    {
        UserId = userId;
        NotificationTypeId = notificationTypeId;
        Channel = channel;
        Content = content;
    }
}
