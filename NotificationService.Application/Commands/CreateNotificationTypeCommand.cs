namespace NotificationService.Application.Commands;

public class CreateNotificationTypeCommand
{
    public string Name { get; set; }
    public string Description { get; set; }

    public CreateNotificationTypeCommand(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Notification type name cannot be null or empty.", nameof(name));

        Name = name;
        Description = description;
    }
}
