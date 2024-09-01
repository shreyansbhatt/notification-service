using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Data.EntityConfigurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Content)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(n => n.Channel)
               .IsRequired();

        builder.Property(n => n.Status)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(n => n.SentDate)
               .IsRequired();

        builder.HasOne<NotificationType>()
               .WithMany()
               .HasForeignKey(n => n.NotificationTypeId);
    }
}
