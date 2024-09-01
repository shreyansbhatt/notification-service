using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NotificationService.Infrastructure.Data;

public class NotificationContext : DbContext
{
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }

    public NotificationContext(DbContextOptions<NotificationContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
