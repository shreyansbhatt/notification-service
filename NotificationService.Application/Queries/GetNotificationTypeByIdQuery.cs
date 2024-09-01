namespace NotificationService.Application.Queries;

public class GetNotificationTypeByIdQuery
{
    public Guid Id { get; set; }

    public GetNotificationTypeByIdQuery(Guid id)
    {
        Id = id;
    }
}
