namespace NotificationService.Domain.Entities;

public class NotificationType
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public NotificationType(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }
}
