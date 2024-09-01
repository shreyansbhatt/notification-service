namespace NotificationService.Application.Queries;

public class GetAllNotificationsQuery
{
    public Guid? UserId { get; set; }
    public Guid? NotificationTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public GetAllNotificationsQuery() { }

    public GetAllNotificationsQuery(Guid? userId, Guid? notificationTypeId, DateTime startDate, DateTime endDate)
    {
        UserId = userId;
        NotificationTypeId = notificationTypeId;
        StartDate = startDate;
        EndDate = endDate;
    }
}
