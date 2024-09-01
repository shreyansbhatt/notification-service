using NotificationService.Application.Interfaces;
using NotificationService.Infrastructure.Data;
using NotificationService.Infrastructure.Repositories;

namespace NotificationService.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly NotificationContext _context;
    public INotificationRepository NotificationRepository { get; }
    public INotificationTypeRepository NotificationTypeRepository { get; }

    public UnitOfWork(NotificationContext context)
    {
        _context = context;
        NotificationRepository = new NotificationRepository(_context);
        NotificationTypeRepository = new NotificationTypeRepository(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}