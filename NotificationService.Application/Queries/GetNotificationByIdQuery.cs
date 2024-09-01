namespace NotificationService.Application.Queries;

public class GetNotificationByIdQuery
{
    public Guid Id { get; set; }

    public GetNotificationByIdQuery(Guid id)
    {
        Id = id;
    }
}
