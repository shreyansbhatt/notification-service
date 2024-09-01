namespace NotificationService.Application.Commands
{
    public class UpdateNotificationTypeCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UpdateNotificationTypeCommand(Guid id, string name, string description)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Notification type ID cannot be an empty GUID.", nameof(id));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Notification type name cannot be null or empty.", nameof(name));

            Id = id;
            Name = name;
            Description = description;
        }
    }
}
