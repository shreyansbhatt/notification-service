using NotificationService.Application.Commands;
using NotificationService.Application.Interfaces;
using NotificationService.Application.Queries;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Services;

public class NotificationTypeService : INotificationTypeService
{
    private readonly IUnitOfWork _unitOfWork;

    public NotificationTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationType>> CreateNotificationTypeAsync(CreateNotificationTypeCommand command)
    {
        if (command == null)
            return Result<NotificationType>.Failure("Command cannot be null.");

        var notificationType = new NotificationType
        (
            command.Name,
            command.Description
        );

        await _unitOfWork.NotificationTypeRepository.AddAsync(notificationType);
        await _unitOfWork.CompleteAsync();

        return Result<NotificationType>.SuccessResult(notificationType);
    }

    public async Task<Result<NotificationType>> UpdateNotificationTypeAsync(UpdateNotificationTypeCommand command)
    {
        if (command == null)
            return Result<NotificationType>.Failure("Command cannot be null.");

        var notificationType = await _unitOfWork.NotificationTypeRepository.GetByIdAsync(command.Id);
        if (notificationType == null)
            return Result<NotificationType>.Failure("Notification type not found.");

        notificationType.UpdateName(command.Name);
        notificationType.UpdateName(command.Description);

        _unitOfWork.NotificationTypeRepository.Update(notificationType);
        await _unitOfWork.CompleteAsync();

        return Result<NotificationType>.SuccessResult(notificationType);
    }

    public async Task<Result> DeleteNotificationTypeAsync(DeleteNotificationTypeCommand command)
    {
        if (command == null)
            return Result.Failure("Command cannot be null.");

        var notificationType = await _unitOfWork.NotificationTypeRepository.GetByIdAsync(command.Id);
        if (notificationType == null)
            return Result.Failure("Notification type not found.");

        _unitOfWork.NotificationTypeRepository.Remove(notificationType);
        await _unitOfWork.CompleteAsync();

        return Result.SuccessResult();
    }

    public async Task<NotificationType?> GetNotificationTypeByIdAsync(GetNotificationTypeByIdQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var notificationType = await _unitOfWork.NotificationTypeRepository.GetByIdAsync(query.Id);
        return notificationType;
    }

    public async Task<IEnumerable<NotificationType?>> GetAllNotificationTypesAsync()
    {
        var notificationTypes = await _unitOfWork.NotificationTypeRepository.GetAllAsync();
        return notificationTypes;
    }
}
