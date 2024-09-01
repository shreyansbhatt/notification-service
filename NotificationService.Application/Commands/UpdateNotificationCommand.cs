using Channel = NotificationService.Domain.Enums.Channel;

namespace NotificationService.Application.Commands;

public class UpdateNotificationCommand
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid NotificationTypeId { get; set; }
    public Channel Channel { get; set; }
    public string Content { get; set; }
    public DateTime SentDate { get; set; }
    public string Status { get; set; }

    public UpdateNotificationCommand(Guid id, Guid userId, Guid notificationTypeId, Channel channel, string content, DateTime sentDate, string status)
    {
        Id = id;
        UserId = userId;
        NotificationTypeId = notificationTypeId;
        Channel = channel;
        Content = content;
        SentDate = sentDate;
        Status = status;
    }
}
