using NotificationService.Application.Commands;
using NotificationService.Application.Interfaces;
using NotificationService.Application.Queries;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Services;

public class NotificationService : INotificationService
{
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Notification>> SendNotificationAsync(SendNotificationCommand command)
    {
        // Validate input
        if (command == null)
            return Result<Notification>.Failure("Command cannot be null.");

        var notificationType = await _unitOfWork.NotificationTypeRepository.GetByIdAsync(command.NotificationTypeId);
        if (notificationType == null)
            return Result<Notification>.Failure("Invalid notification type.");

        var notification = new Notification
        (
            Guid.NewGuid(),
            command.UserId,
            command.NotificationTypeId,
            command.Channel,
            command.Content,
            DateTime.UtcNow,
            "Sent"
        );

        await _unitOfWork.NotificationRepository.AddAsync(notification);
        await _unitOfWork.CompleteAsync();

        return Result<Notification>.SuccessResult(notification);
    }

    public async Task<Notification?> GetNotificationByIdAsync(GetNotificationByIdQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var notification = await _unitOfWork.NotificationRepository.GetByIdAsync(query.Id);
        return notification;
    }

    public async Task<IEnumerable<Notification>> GetAllNotificationsAsync(GetAllNotificationsQuery query)
    {
        var notifications = await _unitOfWork.NotificationRepository.GetAllAsync(
            n => (query.UserId == null || n.UserId == query.UserId) &&
                 (query.NotificationTypeId == null || n.NotificationTypeId == query.NotificationTypeId) &&
                 (n.SentDate >= query.StartDate && n.SentDate <= query.EndDate)
        );

        return notifications;
    }

    public async Task<Result> DeleteNotificationAsync(DeleteNotificationCommand command)
    {
        if (command == null)
            return Result.Failure("Command cannot be null.");

        var notification = await _unitOfWork.NotificationRepository.GetByIdAsync(command.Id);
        if (notification == null)
            return Result.Failure("Notification not found.");

        _unitOfWork.NotificationRepository.Remove(notification);
        await _unitOfWork.CompleteAsync();

        return Result.SuccessResult();
    }
}
