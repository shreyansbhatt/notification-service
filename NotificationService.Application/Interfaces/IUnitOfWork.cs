namespace NotificationService.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    INotificationRepository NotificationRepository { get; }
    INotificationTypeRepository NotificationTypeRepository { get; }
    Task<int> CompleteAsync();
}
