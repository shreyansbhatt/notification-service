namespace NotificationService.Application.Commands;

public class DeleteNotificationCommand
{
    public Guid Id { get; set; }

    public DeleteNotificationCommand(Guid id)
    {
        Id = id;
    }
}
