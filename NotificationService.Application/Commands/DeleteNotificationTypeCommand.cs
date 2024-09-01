namespace NotificationService.Application.Commands;

public class DeleteNotificationTypeCommand
{
    public Guid Id { get; set; }

    public DeleteNotificationTypeCommand(Guid id)
    {
        Id = id;
    }
}
