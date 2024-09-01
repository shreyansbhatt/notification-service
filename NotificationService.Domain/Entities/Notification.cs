using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Entities;

public class Notification
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid NotificationTypeId { get; private set; }
    public Channel Channel { get; private set; }
    public string Content { get; private set; }
    public DateTime SentDate { get; private set; }
    public string Status { get; private set; }

    public Notification(Guid userId, Guid notificationTypeId, Channel channel, string content)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        NotificationTypeId = notificationTypeId;
        Channel = channel;
        Content = content;
        SentDate = DateTime.UtcNow;
        Status = "Pending";
    }

    public Notification(Guid guid, Guid userId, Guid notificationTypeId, Channel channel, string content, DateTime utcNow, string status)
    {
        Id= guid;
        UserId = userId;
        NotificationTypeId = notificationTypeId;
        Channel = channel;
        Content = content;
        SentDate = utcNow;
        Status = status;
    }

    public void MarkAsSent()
    {
        Status = "Sent";
    }

    public void MarkAsFailed(string reason)
    {
        Status = $"Failed: {reason}";
    }
}
